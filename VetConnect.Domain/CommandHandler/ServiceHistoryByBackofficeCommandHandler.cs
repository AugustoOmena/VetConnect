using MediatR;
using VetConnect.Domain.Commands.Pets.Backoffice;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Domain.Results.ServiceVet;
using VetConnect.Domain.Validators;
using VetConnect.Domain.ViewModels.Services;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Persistence;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.CommandHandler;

public class ServiceHistoryByBackofficeCommandHandler: BaseCommandHandler,
    IRequestHandler<CreateServiceByBackofficeCommand, BaseServiceHistoryResult>,
    IRequestHandler<ListServiceHistoryQuery, PagedList<ServiceHistoryVm>>,
    IRequestHandler<DeleteServiceCommand, BaseServiceHistoryResult>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceHistoryRepository _serviceHistoryRepository;
    
    public ServiceHistoryByBackofficeCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IPetRepository petRepository, IUserRepository userRepository, IServiceHistoryRepository serviceHistoryRepository) : base(uow, notifications)
    {
        _petRepository = petRepository;
        _userRepository = userRepository;
        _serviceHistoryRepository = serviceHistoryRepository;
    }

    public async Task<BaseServiceHistoryResult> Handle(CreateServiceByBackofficeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseServiceHistoryResult();
        
        var validator = new CreateServiceHistoryValidator();
        
        // Solução provisória, o ideal é buscar o tipo de usuário por Claim
        var sessionUser = await _userRepository.FindAsync(x => x.Id == request.SessionUser.Id && x.DateDeleted == null);

        if (sessionUser.UserType is not (EUserType.BackOffice or EUserType.Admin) )
        {
            Notifications.Handle("Usuário não tem autorização.");
            return response;
        }
        
        var pet = await _petRepository.FindAsync(x => x.Id == request.PetId && x.DateDeleted == null);

        if (pet is null)
        {
            Notifications.Handle("Pet não encontrado");
            return response;
        }

        //essa intância foi criada para garantir que os dados são válidos
        var newPetRequest = new CreateServiceByBackofficeCommand()
        {
            Name = request.Name,
            Description = request.Description,
            Pet = request.Pet,
            PetId = request.PetId,
            Price = request.Price,
            SessionUser = request.SessionUser
        };
        
        var validationResult = await validator.ValidateAsync(newPetRequest, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Message = validationResult.ToString();
            return response;
        }

        var newService = ServiceHistory.New(
            request.Name,
            request.Description,
            request.Price,
            request.PetId
            );

        await _serviceHistoryRepository.AddServiceAsync(newService);
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Opa, houve um problema ao salvar os dados, por favor tente novamente mais tarde");
            return response;
        }

        response.Message = "Sucesso ao criar o serviço";
        response.Success = true;
        return response;
    }

    public async Task<PagedList<ServiceHistoryVm>> Handle(ListServiceHistoryQuery query, CancellationToken cancellationToken)
    {
        // Solução provisória, o ideal é buscar o tipo de usuário por Claim
        var sessionUser = await _userRepository.FindAsync(x => x.Id == query.SessionUser.Id && x.DateDeleted == null);

        if (sessionUser.UserType is not (EUserType.BackOffice or EUserType.Admin) )
        {
            Notifications.Handle("Usuário não tem autorização.");
            return null;
        }
        
        var where = _serviceHistoryRepository.Where(query.Filter);
        
        var includes = new IncludeHelper<ServiceHistory>()
            .Include(x => x.Pet)
            .Includes;
        
        var count = _serviceHistoryRepository.ListAsNoTracking(where, query.Filter);
        
        var services = _serviceHistoryRepository
            .ListAsNoTracking(where, query.Filter, includes)
            .ToVm();
        
        return new PagedList<ServiceHistoryVm>(services, count.Count(), query.Filter.PageSize);
    }

    public async Task<BaseServiceHistoryResult> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        var result = new BaseServiceHistoryResult();
        var service = await _serviceHistoryRepository.FindAsync(x => x.Id == command.Id && x.DateDeleted == null);
        
        if (service == null)
        {
            Notifications.Handle("Pet não encontrado");
            return result;
        }
        
        service.Delete();
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Houve um probema ao salvar as informações");
            return result;
        }
        
        result.Success = true;
        result.Message = "Exclusão feita com sucesso";
        return result;
    }
}
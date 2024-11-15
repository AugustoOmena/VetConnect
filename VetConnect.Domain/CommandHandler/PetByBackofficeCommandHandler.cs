using MediatR;
using VetConnect.Domain.Commands.Pets;
using VetConnect.Domain.Commands.Pets.Backoffice;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Results.Pet;
using VetConnect.Domain.Validators;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.CommandHandler;

public class PetByBackofficeCommandHandler : BaseCommandHandler,
    IRequestHandler<CreatePetByBackofficeCommand, BasePetResult>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserRepository _userRepository;
    
    public PetByBackofficeCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IPetRepository petRepository, IUserRepository userRepository) : base(uow, notifications)
    {
        _petRepository = petRepository;
        _userRepository = userRepository;
    }

    public async Task<BasePetResult> Handle(CreatePetByBackofficeCommand request, CancellationToken cancellationToken)
    {
        // Obs: Liberado para requisições de qualquer tipo de usuário logado. Ideal atualizar método e endpoint
        
        var response = new BasePetResult();
        
        var validator = new CreatePetValidator();
        
        var user = await _userRepository.FindAsync(x => x.Id == request.UserId && x.DateDeleted == null);

        if (user is null)
        {
            Notifications.Handle("Usuário não encontrado");
            return response;
        }

        var newPetRequest = new CreatePetCommand
        {
            Name = request.Name,
            BirthDate = request.BirthDate,
            PetType = request.PetType,
            Race = request.Race,
            SessionUser = request.SessionUser
        };
        
        var validationResult = await validator.ValidateAsync(newPetRequest, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Message = validationResult.ToString();
            return response;
        }

        var newPet = Pet.New(
            request.Name,
            request.PetType,
            request.Race,
            request.BirthDate,
            request.UserId
        );

        await _petRepository.AddPetAsync(newPet);
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Opa, houve um problema ao salvar os dados, por favor tente novamente mais tarde");
            return response;
        }

        response.Success = true;
        return response;
    }
}
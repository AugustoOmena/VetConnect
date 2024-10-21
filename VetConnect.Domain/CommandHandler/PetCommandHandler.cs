using MediatR;
using VetConnect.Domain.Commands.Pets;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Results.Pet;
using VetConnect.Domain.Validators;
using VetConnect.Shared.Notifications;
using IUnitOfWork = VetConnect.Shared.Persistence.IUnitOfWork;

namespace VetConnect.Domain.CommandHandler;

public class PetCommandHandler : BaseCommandHandler,
    IRequestHandler<CreatePetCommand, BasePetResult>
{

    private readonly IPetRepository _petRepository;
    
    public PetCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IPetRepository petRepository) : base(uow, notifications)
    {
        _petRepository = petRepository;
    }

    public async Task<BasePetResult> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var response = new BasePetResult();
        
        var validator = new CreatePetValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Message = "opa, algo não funcionou";
            return response;
        }

        var newPet = Pet.New(
            request.Name,
            request.PetType,
            request.Race,
            request.BirthDate,
            request.SessionUser.Id
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
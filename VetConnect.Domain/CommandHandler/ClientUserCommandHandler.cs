using VetConnect.Shared.Notifications;
using VetConnect.Shared.Persistence;
using MediatR;
using VetConnect.Domain.Commands.Auth;
using VetConnect.Domain.Commands.UserClient;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Results.Auth;
using VetConnect.Domain.Results.UserClient;
using VetConnect.Domain.Services.Contracts;
using VetConnect.Domain.Validators;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.CommandHandler;

public class ClientUserCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateClientUserByVetConnectCommand, BaseClientUserResult>,
    IRequestHandler<AuthorizeUserCommand, AuthorizeUserResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public ClientUserCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository, IJwtService jwtService) : base(uow, notifications)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<BaseClientUserResult> Handle(CreateClientUserByVetConnectCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseClientUserResult();
        
        var validator = new CreateClientUserValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Message = "opa, algo não funcionou";
            return response;
        }

        var newUser = User.New(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Phone,
            request.Password,
            request.UserType
        );

        await _userRepository.AddUserAsync(newUser);
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Opa, houve um problema ao salvar os dados, por favor tente novamente mais tarde");
            return response;
        }

        response.Success = true;
        return response;
    }

    public async Task<AuthorizeUserResult> Handle(AuthorizeUserCommand command, CancellationToken cancellationToken)
    {
        var response = new AuthorizeUserResult();
        
        var validator = new AuthUserValidator();
        var validationResult = await validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
        {
            response.Success = false;
            return response;
        }

        var user = await _userRepository.FindAsync(x => x.Email.ToLower() == command.Email.ToLower() && x.Password == command.Password);
        
        var sessionUser = new SessionUser
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserType = user.UserType
        };
        
        if (user is not null)
        {
            response.User = sessionUser;
            response.AccessToken = _jwtService.GenerateToken(user);
            response.Success = true;
            return (response);
        }
        
        return (response);
    }
}
using ClinicManagementSystem.Domain.Commands.Auth;
using ClinicManagementSystem.Domain.Commands.UserClient;
using ClinicManagementSystem.Domain.Contracts.Repositories;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Results.Auth;
using ClinicManagementSystem.Domain.Results.UserClient;
using ClinicManagementSystem.Domain.Services.Contracts;
using ClinicManagementSystem.Domain.Validators;
using ClinicManagementSystem.Shared.Notifications;
using ClinicManagementSystem.Shared.Persistence;
using MediatR;

namespace ClinicManagementSystem.Domain.CommandHandler;

public class ClientUserCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateClientUserByClinicManagementSystemCommand, BaseClientUserResult>,
    IRequestHandler<AuthorizeUserCommand, AuthorizeUserResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public ClientUserCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository, IJwtService jwtService) : base(uow, notifications)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<BaseClientUserResult> Handle(CreateClientUserByClinicManagementSystemCommand request, CancellationToken cancellationToken)
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
            request.Name,
            request.Email,
            request.Password,
            request.UserType
        );

        await _userRepository.AddUserAsync(newUser);
        
        if (!await CommitAsync())
        {
            Notifications.Handle("CommonMessages.ProblemSavindDataFriendly");
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

        if (user is not null)
        {
            response.AccessToken = _jwtService.GenerateToken(user);
            response.Success = true;
            return (response);
        }
        
        throw new NotImplementedException();
    }
}
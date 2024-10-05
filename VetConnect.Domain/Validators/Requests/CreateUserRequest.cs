using VetConnect.Shared.Enums;
using MediatR;
using VetConnect.Domain.Results.UserClient;

namespace VetConnect.Domain.Validators.Requests;

public sealed record CreateUserRequest(string Email, string Name, string Password, EUserType UserType) :
    IRequest<CreateUserResult>
{
    
}
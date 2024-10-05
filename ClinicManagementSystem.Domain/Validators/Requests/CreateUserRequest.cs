using ClinicManagementSystem.Domain.Results.UserClient;
using ClinicManagementSystem.Shared.Enums;
using MediatR;

namespace ClinicManagementSystem.Domain.Validators.Requests;

public sealed record CreateUserRequest(string Email, string Name, string Password, EUserType UserType) :
    IRequest<CreateUserResult>
{
    
}
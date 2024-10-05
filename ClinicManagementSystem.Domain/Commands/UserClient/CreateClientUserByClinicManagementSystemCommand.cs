using ClinicManagementSystem.Domain.Results.UserClient;
using ClinicManagementSystem.Shared.Enums;
using MediatR;

namespace ClinicManagementSystem.Domain.Commands.UserClient;

public class CreateClientUserByClinicManagementSystemCommand: IRequest<BaseClientUserResult>
{
    public string Name { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public EUserType UserType { get; set; }
}
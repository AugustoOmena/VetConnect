using VetConnect.Shared.Enums;
using MediatR;
using VetConnect.Domain.Results.UserClient;

namespace VetConnect.Domain.Commands.UserClient;

public class CreateClientUserByVetConnectCommand: IRequest<BaseClientUserResult>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Phone { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public EUserType UserType { get; set; }
}
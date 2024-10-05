using System.ComponentModel.DataAnnotations;
using ClinicManagementSystem.Shared.Enums;

namespace ClinicManagementSystem.API.UseCases.CreateUser;

public sealed record CreateUserResponse
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }

    public string Password { get; set; }
    
    public EUserType UserType { get; set; }
}
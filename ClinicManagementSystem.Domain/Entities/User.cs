using ClinicManagementSystem.Shared.Enums;

namespace ClinicManagementSystem.Domain.Entities;

public class User : BaseEntity
{
    protected User(){}
    public string? Email { get; private set; }
    public string Name { get; private set; }
    public string Password { get; private set; }
    public EUserType UserType { get; private set; }
    
    public static User New(
        string name,
        string email,
        string password,
        EUserType userType
    ) => new User
    {
        DateCreated = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        Name = name,
        Email = email,
        Password = password,
        UserType = userType,
    };
}
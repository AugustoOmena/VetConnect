using VetConnect.Shared.Enums;

namespace VetConnect.Domain.Entities;

public class User : BaseEntity
{
    protected User(){}
    public string? Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public string? Phone { get; private set; }
    public string Password { get; private set; }
    public EUserType UserType { get; private set; }
    
    public static User New(
        string firstName,
        string lastName,
        string email,
        string phone,
        string password,
        EUserType userType
    ) => new User
    {
        DateCreated = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        FirstName = firstName,
        LastName = lastName,
        Email = email,
        Phone = phone,
        Password = password,
        UserType = userType,
    };
}
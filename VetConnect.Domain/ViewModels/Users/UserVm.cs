using VetConnect.Shared.Enums;

namespace VetConnect.Domain.ViewModels.Users;

public class UserVm : BaseVm
{
    public string? Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string? Phone { get; set; }
    public string Password { get; set; }
    public EUserType UserType { get; set; }
    
    // Relacionamento 1:N - Um User pode ter vários Pets
    // public ICollection<Pet> Pets { get; set; } = new List<Pet>();

}
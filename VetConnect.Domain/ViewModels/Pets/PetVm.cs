using VetConnect.Shared.Enums;

namespace VetConnect.Domain.ViewModels.Pets;

public class PetVm : BaseVm
{
    public string Name { get; set; }
    
    public EPetType PetType { get; set; }
    
    public string Race { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    public Guid UserId { get; set; }

}
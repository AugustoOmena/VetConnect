using VetConnect.Domain.ViewModels.Pets;

namespace VetConnect.Domain.ViewModels.Services;

public class ServiceHistoryVm : BaseVm
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }

    public Guid PetId { get; set; }
    
    public PetVm Pet { get; set; }
}
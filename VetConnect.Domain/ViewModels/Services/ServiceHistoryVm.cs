using VetConnect.Domain.Entities;

namespace VetConnect.Domain.ViewModels.Services;

public class ServiceHistoryVm
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }

    public Guid PetId { get; set; }
    
    public Pet Pet { get; set; }
}
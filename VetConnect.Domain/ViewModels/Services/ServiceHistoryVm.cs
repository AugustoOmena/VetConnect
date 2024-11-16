using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Shared.Enums;

namespace VetConnect.Domain.ViewModels.Services;

public class ServiceHistoryVm : BaseVm
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public EServiceType ServiceType { get; set; }
    
    public decimal Price { get; set; }
    
}
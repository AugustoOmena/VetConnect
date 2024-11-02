using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Services;

namespace VetConnect.Domain.Projections;

public static class ServiceHistoryProjections
{
    public static ServiceHistoryVm ToVm(this ServiceHistory serviceHistory) => new ServiceHistoryVm()
    {
        Name = serviceHistory.Name,
        Price = serviceHistory.Price,
        Description = serviceHistory.Description,
        PetId = serviceHistory.PetId,
        Pet = serviceHistory.Pet.ToVm()
    };
    
    public static IEnumerable<ServiceHistoryVm> ToVm(this IEnumerable<ServiceHistory> services) => 
        services.Select(service => service.ToVm());   
}
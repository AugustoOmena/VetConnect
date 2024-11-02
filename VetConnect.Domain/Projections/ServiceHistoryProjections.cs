using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Services;

namespace VetConnect.Domain.Projections;

public static class ServiceHistoryProjections
{
    public static ServiceHistoryVm ToVm(this ServiceHistory serviceHistory) => new ServiceHistoryVm()
    {
        Name = serviceHistory.Name,
        Description = serviceHistory.Description,
        PetId = serviceHistory.PetId,
        Pet = serviceHistory.Pet
    };
    
    public static IEnumerable<ServiceHistoryVm> ToVm(this IEnumerable<ServiceHistory> services) => 
        services.Select(service => service.ToVm());   
}
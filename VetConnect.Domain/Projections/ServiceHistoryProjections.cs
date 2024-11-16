using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Services;

namespace VetConnect.Domain.Projections;

public static class ServiceHistoryProjections
{
    public static ServiceHistoryVm ToVm(this ServiceHistory serviceHistory) => new ServiceHistoryVm()
    {
        Id = serviceHistory.Id,
        Name = serviceHistory.Name,
        Price = serviceHistory.Price,
        Description = serviceHistory.Description,
        ServiceType = serviceHistory.ServiceType
    };
    
    public static IEnumerable<ServiceHistoryVm> ToVm(this IEnumerable<ServiceHistory> services) => 
        services.Select(service => service.ToVm());   
}
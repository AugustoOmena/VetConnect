using VetConnect.Domain.Entities;
using VetConnect.Shared.Paging;

namespace VetConnect.Domain.Filters;

public class ListServicesHistoryFilter : Pagination
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal HighestPrice { get; set; }
    
    public decimal LowestPrice { get; set; }

    public Guid PetId { get; set; }
    
    public Pet Pet { get; set; }
}
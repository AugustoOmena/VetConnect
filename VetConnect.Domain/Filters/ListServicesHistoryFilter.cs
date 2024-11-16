using System.Text.Json.Serialization;
using VetConnect.Domain.Entities;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Paging;

namespace VetConnect.Domain.Filters;

public class ListServicesHistoryFilter : Pagination
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal HighestPrice { get; set; }
    
    public decimal LowestPrice { get; set; }
    
    public EServiceType ServiceType { get; set; }

    [JsonIgnore]
    public Guid PetId { get; set; }
    
    [JsonIgnore]
    public Pet Pet { get; set; }
}
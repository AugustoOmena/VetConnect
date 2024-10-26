using VetConnect.Shared.Paging;

namespace VetConnect.Domain.Filters;

public class ListUserPetsFilter : Pagination
{
    public string? Name { get; set; }
    
    public DateTime? StartAgeDate { get; set; }
    
    public DateTime? EndAgeDate { get; set; }
}
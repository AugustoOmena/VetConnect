using VetConnect.Shared.Paging;

namespace VetConnect.Domain.Filters;

public class ListSchedulingFilter : Pagination
{
    public string? Description { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
}

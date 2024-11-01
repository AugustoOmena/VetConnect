using VetConnect.Shared.Paging;

namespace VetConnect.Domain.Filters;

public class ListUserFilter : Pagination
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Email { get; set; }

    // public bool? Active { get; set; }
}
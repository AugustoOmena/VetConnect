using ClinicManagementSystem.Shared.Paging;

namespace ClinicManagementSystem.Domain.Filters;

public class UserFilter : Pagination
{
    public string Name { get; set; }

    public string Email { get; set; }

    //public bool? Active { get; set; }
}
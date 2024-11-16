using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Filters;
using VetConnect.Domain.ViewModels.Scheduling;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Queries.Users;

public class SchedulingByUserQuery: IRequest<PagedList<SchedulingVm>>
{
    public ListSchedulingFilter Filter { get; set; }
    
    [JsonIgnore]
    public SessionUser SessionUser { get; set; }
}
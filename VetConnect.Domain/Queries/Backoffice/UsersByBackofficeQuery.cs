using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Filters;
using VetConnect.Domain.ViewModels.Users;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Queries.Backoffice;

public class UsersByBackofficeQuery: IRequest<PagedList<UserVm>>
{
    public ListUserFilter Filter { get; set; }
    
    [JsonIgnore]
    public SessionUser SessionUser { get; set; }
}
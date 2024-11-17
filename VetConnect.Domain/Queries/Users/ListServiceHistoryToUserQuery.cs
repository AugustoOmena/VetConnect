using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Filters;
using VetConnect.Domain.ViewModels.Services;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Queries.Users;

public class ListServiceHistoryToUserQuery: IRequest<PagedList<ServiceHistoryVm>>
{
    public ListServicesHistoryFilter Filter { get; set; }
    
    [JsonIgnore]
    public SessionUser SessionUser { get; set; }
}
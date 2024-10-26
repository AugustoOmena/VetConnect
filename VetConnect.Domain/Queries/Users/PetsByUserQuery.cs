using MediatR;
using Newtonsoft.Json;
using VetConnect.Domain.Filters;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Queries.Users;

public class PetsByUserQuery: IRequest<PagedList<PetVm>>
{
    public ListUserPetsFilter Filter { get; set; }
    
    [JsonIgnore]
    public SessionUser SessionUser { get; set; }
}
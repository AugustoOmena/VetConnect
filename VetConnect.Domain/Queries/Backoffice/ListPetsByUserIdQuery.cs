using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Filters;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Queries.Backoffice;

public class ListPetsByUserIdQuery: IRequest<PagedList<PetVm>>
{
    [JsonIgnore]
    public Guid? Id { get; set; }
    
    [JsonIgnore]
    public ListUserPetsFilter Filter { get; set; }
    
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
}
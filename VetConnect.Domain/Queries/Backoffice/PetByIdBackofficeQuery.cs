using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.ViewModels.Pets;

namespace VetConnect.Domain.Queries.Backoffice;

public class PetByIdBackofficeQuery: IRequest<PetVm>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
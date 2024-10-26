using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Results.Pet;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Pets;

public class DeletePetCommand : IRequest<BasePetResult>
{
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
    public Guid Id { get; set; }
}
using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Results.ServiceVet;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Pets.Backoffice;

public class DeleteServiceCommand : IRequest<BaseServiceHistoryResult>
{
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
    public Guid Id { get; set; }
}
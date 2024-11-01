using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.ViewModels.Users;

namespace VetConnect.Domain.Queries.Backoffice;

public class UserByBackofficeQuery : IRequest<UserVm>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
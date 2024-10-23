using System.Security.Claims;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Contracts.Infra;

public interface ILoggedUser
{
    SessionUser User { get; }
    bool IsAuthenticated();
    IEnumerable<Claim> GetClaims();
    Guid Id { get; }
    EUserType? Type { get; }
}
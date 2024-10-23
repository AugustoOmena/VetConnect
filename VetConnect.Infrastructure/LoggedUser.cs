using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Shared.Constants;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Extensions;
using VetConnect.Shared.Security;

namespace VetConnect.Infrastructure;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _accessor;
    
    public LoggedUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public SessionUser User 
    {
        get
        {
            var claims = GetClaims().ToList();

            if (!claims.Any())
            {
                return null;
            }

            try
            {
                return SessionUser.User(claims);
            }
            catch
            {
                return null;
            }
        }
    }
    
    public bool IsAuthenticated() =>
        _accessor.HttpContext.User.Identity.IsAuthenticated;

    public IEnumerable<Claim> GetClaims() =>
        _accessor.HttpContext.User.Claims;

    public Guid Id 
    {
        get
        {
            var value = GetClaims().FirstOrDefault(x => x.Type == CustomClaims.Id)?.Value ?? "";
            return Guid.TryParse(value, out var id)
                ? id
                : Guid.Empty;
        }
    }
    
    public EUserType? Type 
    {
        get
        {
            var userType = GetClaims().FirstOrDefault(x => x.Type == CustomClaims.Type)?.Value?.ToEnumValue<EUserType>();
            if (!userType.HasValue)
                return null;

            return userType.Value;
        }
    }
}
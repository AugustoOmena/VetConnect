using System.Security.Claims;
using VetConnect.Shared.Constants;

namespace VetConnect.Shared.Security;

    public class SessionUser
    {
        public Guid Id { get; set; }
        
        public string? Email { get; set; }
        
        public string? Name { get; set; }
        
        // public EUserType? UserType { get; set; }

        public static SessionUser User(IEnumerable<Claim> claims)
        {
            var sessionUser = new SessionUser();

            var claimsArray = claims as Claim[] ?? claims.ToArray();

            sessionUser.Email = claimsArray
                .FirstOrDefault(x => x.Type == CustomClaims.Email || x.Type == ClaimTypes.Email)?.Value;

            sessionUser.Name = claimsArray
                .FirstOrDefault(x => x.Type == CustomClaims.Name || x.Type == ClaimTypes.Name)?.Value;
            
            sessionUser.Id = Guid.Parse(claimsArray.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            //
            // if (claimsArray.Any(x => x.Type == CustomClaims.UserType &&
            //                          !string.IsNullOrWhiteSpace(x.Value)) &&
            //     Enum.TryParse<EUserType>(claimsArray.First(x => x.Type == CustomClaims.UserType).Value, out var userType))
            // {
            //     sessionUser.UserType = userType;
            // }
            
            //TODO SysAdmin claims
            
            return sessionUser;
        }

        public ICollection<Claim> Claims()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(CustomClaims.Id, Id.ToString()));
            claims.Add(new Claim(CustomClaims.Email, Email));
            claims.Add(new Claim(CustomClaims.Name, Name ?? ""));
            
            // if (UserType != null)
            // {
            //     claims.Add(new Claim(CustomClaims.UserType, UserType.ToString()));
            // }
            // if (UserType.HasValue)
            // {
            //     claims.Add(new Claim(CustomClaims.UserType, UserType.Value.ToString()));
            //     // claims.Add(new Claim(CustomClaims.AcceptedTerms, AcceptedTerms.GetValueOrDefault(false).ToString()));
            //     // claims.Add(new Claim(CustomClaims.Identification,Identification?.Formatted ?? ""));
            // }

            //TODO SysAdmin claims

            return claims;
        }

        public virtual ClaimsPrincipal ClaimsPrincipal() => new ClaimsPrincipal(new[] {new ClaimsIdentity(Claims())});
    }
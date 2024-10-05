using System.Security.Claims;
using VetConnect.Shared.Constants;

namespace VetConnect.Shared.Security;

    public class SessionUser
    {
        public Guid Id { get; set; }
        
        public string? Email { get; set;}
        
        public string? Name { get; set; }

        public static SessionUser User(IEnumerable<Claim> claims)
        {
            var sessionUser = new SessionUser();

            var claimsArray = claims as Claim[] ?? claims.ToArray();

            sessionUser.Id = Guid.Parse(claimsArray.First(x => x.Type == CustomClaims.Id).Value);

            sessionUser.Email = claimsArray
                .FirstOrDefault(x => x.Type == CustomClaims.Email || x.Type == ClaimTypes.Email)?.Value;

            sessionUser.Name = claimsArray.FirstOrDefault(x => x.Type == CustomClaims.Name)
                ?.Value;
       
            //TODO SysAdmin claims
            
            return sessionUser;
        }

        public ICollection<Claim> Claims()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(CustomClaims.Id, Id.ToString()));
            claims.Add(new Claim(CustomClaims.Email, Email));
            claims.Add(new Claim(CustomClaims.Name, Name ?? ""));
            
            // if (Type.HasValue)
            // {
            //     claims.Add(new Claim(CustomClaims.Type, Type.Value.ToString()));
            //     claims.Add(new Claim(CustomClaims.AcceptedTerms, AcceptedTerms.GetValueOrDefault(false).ToString()));
            //     claims.Add(new Claim(CustomClaims.Identification,Identification?.Formatted ?? ""));
            // }

            //TODO SysAdmin claims

            return claims;
        }

        public virtual ClaimsPrincipal ClaimsPrincipal() => new ClaimsPrincipal(new[] {new ClaimsIdentity(Claims())});
    }
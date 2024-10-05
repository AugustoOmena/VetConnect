using ClinicManagementSystem.Shared.Security;

namespace ClinicManagementSystem.Domain.Results.Auth;

public class AuthorizeUserResult
{
    public SessionUser? User { get; set; }
 
    public string? AccessToken { get; set; }
    
    public DateTime? ExpiresIn { get; set; }
    
    public string? RefreshToken { get; set; }

    public bool Success { get; set; } = false;

    public string? Error { get; set; }
}

namespace ClinicManagementSystem.Domain.Results.UserClient;

public class BaseClientUserResult
{
    public string Error { get; set; }
        
    public string Message { get; set; }
        
    public bool Success { get; set; } = false;
}
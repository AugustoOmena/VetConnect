namespace VetConnect.Domain.Results.ServiceVet;

public class BaseServiceHistoryResult
{
    public string Error { get; set; }
        
    public string Message { get; set; }
        
    public bool Success { get; set; } = false;
}
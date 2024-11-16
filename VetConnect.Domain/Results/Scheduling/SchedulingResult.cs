namespace VetConnect.Domain.Results.Scheduling;

public class SchedulingResult
{
    public string Error { get; set; }
        
    public string Message { get; set; }
        
    public bool Success { get; set; } = false;
}
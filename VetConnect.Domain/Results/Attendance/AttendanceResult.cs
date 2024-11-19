namespace VetConnect.Domain.Results.Attendance;

public class AttendanceResult
{
    public string Error { get; set; }
        
    public string Message { get; set; }
        
    public bool Success { get; set; } = false;
}
namespace VetConnect.Domain.Results.Pet;

public class BasePetResult
{
    public string Error { get; set; }
        
    public string Message { get; set; }
        
    public bool Success { get; set; } = false;
}
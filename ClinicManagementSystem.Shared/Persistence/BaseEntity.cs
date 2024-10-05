namespace ClinicManagementSystem.Shared.Persistence;

public class BaseEntity 
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public bool Deleted { get; protected set; }
}
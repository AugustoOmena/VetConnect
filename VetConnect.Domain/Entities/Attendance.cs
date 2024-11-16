using VetConnect.Shared.Enums;

namespace VetConnect.Domain.Entities;

public class Attendance : BaseEntity
{
    public string? Description { get; private set; }
    
    public string? Prescription { get; set; }
    
    // Relacionamento N:1 - Um Atendimento pertence a um único usuário atendente
    
    public Guid? AgentId { get; private set; }
    
    
    // Relacionamento N:1 - Um Atendimento pertence a um único agendamento
    
    public Guid SchedulingId { get; private set; }
    
    public Scheduling Scheduling { get; private set; }
    
    public EAttendanceStatus AttendanceStatus { get; private set; }

    public static Attendance New(
        Guid schedulingId
    ) => new Attendance
    {
        Id = Guid.NewGuid(),
        DateCreated = DateTime.UtcNow,
        SchedulingId = schedulingId
    };
    
    public void Update(
        string description,
        string precription
    )
    {
        Description = description;
        DateCreated = DateTime.UtcNow;
        Prescription = precription;
    }

}
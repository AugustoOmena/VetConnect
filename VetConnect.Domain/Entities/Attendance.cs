using VetConnect.Shared.Enums;

namespace VetConnect.Domain.Entities;

public class Attendance : BaseEntity
{
    public string Description { get; private set; }
    
    public DateTimeOffset Data { get; set; }

    
    public string Prescription { get; set; }
    
    // Relacionamento N:1 - Um Atendimento pertence a um único usuário atendente
    
    public Guid AgentId { get; private set; }
    
    public Guid AppointmentId { get; private set; }
    
    // Relacionamento N:1 - Um Atendimento pertence a um único usuário agendamento
    
    public Guid SchedulingId { get; private set; }
    
    public Scheduling Scheduling { get; private set; }
    
    public EAttendanceStatus AttendanceStatus { get; private set; }

}
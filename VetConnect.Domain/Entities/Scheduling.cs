namespace VetConnect.Domain.Entities;

public class Scheduling : BaseEntity
{
    protected Scheduling(){}
    
    public DateTimeOffset DateInitial { get; set; }
    
    public DateTimeOffset DateEnd { get; set; }
    
    public string Description { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Service
    
    public Guid ServiceId { get; private set; }
    
    public ServiceHistory ServiceHistory { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Pet
    
    public Guid PetId { get; private set; }
    
    public Pet Pet { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pode ter um único Usuário atendido
    
    public Guid UserId { get; private set; }
    
    public User User { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Service
    
    public Guid AttendenceId { get; private set; }
    
    public Attendance Attendance { get; private set; }
    
    
}
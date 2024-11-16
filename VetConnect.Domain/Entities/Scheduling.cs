namespace VetConnect.Domain.Entities;

public class Scheduling : BaseEntity
{
    protected Scheduling(){}
    
    public DateTimeOffset DateInitial { get; set; }
    
    public DateTimeOffset DateEnd { get; set; }
    
    public string Description { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Service
    
    public Guid ServiceHistoryId { get; private set; }

    public Guid ServiceId { get; private set; }

    public ServiceHistory ServiceHistory { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Pet
    
    public Guid PetId { get; private set; }
    
    public Pet Pet { get; private set; }
    
    // Relacionamento N:1 - Um Agendamento pertence a um único Atendimento
    
    public Attendance Attendance { get; private set; }
    
    public Scheduling( 
        Attendance attendence,
        DateTimeOffset initialDate,
        DateTimeOffset endDate,
        string description,
        Guid serviceHistoryId
        )
    {
        DateCreated = DateTime.UtcNow;
        Id = Guid.NewGuid();
        Attendance = attendence;
        DateInitial = initialDate;
        DateEnd = endDate;
        Description = description;
        ServiceHistoryId = serviceHistoryId;
    }
    
    public static Scheduling New(
        DateTimeOffset initialDate,
        DateTimeOffset endDate,
        string description,
        Guid petId,
        Guid serviceId,
        ServiceHistory serviceHistory
    ) => new Scheduling()
    {
        DateCreated = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        DateInitial = initialDate,
        DateEnd = endDate,
        Description = description,
        PetId = petId,
        ServiceHistoryId = serviceId,
        ServiceId = serviceId,
        ServiceHistory = serviceHistory
    };
    
    public void Update(
        DateTimeOffset initialDate,
        DateTimeOffset endDate,
        string description
    )
    {
        DateUppdated = DateTime.UtcNow;
        DateInitial = initialDate;
        DateEnd = endDate;
        Description = description;
    }
    
    public void Delete()
    {
        DateDeleted = DateTime.UtcNow;
    }
}
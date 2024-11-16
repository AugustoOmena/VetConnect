using VetConnect.Domain.ViewModels.Scheduling;
using VetConnect.Shared.Enums;

namespace VetConnect.Domain.ViewModels.Attendance;

public class AttendanceVm : BaseVm
{
    public string Description { get; set; }
    
    public DateTimeOffset Data { get; set; }

    public string Prescription { get; set; }
    
    public Guid AgentId { get; set; }
    
    public Guid AppointmentId { get; set; }
    
    public Guid SchedulingId { get; set; }
    
    public SchedulingVm Scheduling { get; set; }
    
    public EAttendanceStatus AttendanceStatus { get; set; }
}
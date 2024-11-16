using VetConnect.Domain.ViewModels.Attendance;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Domain.ViewModels.Services;
using VetConnect.Domain.ViewModels.Users;

namespace VetConnect.Domain.ViewModels.Scheduling;

public class SchedulingVm : BaseVm
{
    public DateTimeOffset DateInitial { get; set; }
    
    public DateTimeOffset DateEnd { get; set; }
    
    public string Description { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public ServiceHistoryVm ServiceHistory { get; set; }
    
    public Guid PetId { get; set; }
    
    public PetVm Pet { get; set; }
    
    public Guid UserId { get; set; }
    
    public UserVm User { get; set; }
    
    public Guid AttendenceId { get; set; }
    
    public AttendanceVm Attendance { get; set; }
}
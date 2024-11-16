using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Scheduling;

namespace VetConnect.Domain.Projections;

public static class SchedulingProjections
{
    public static SchedulingVm ToVm(this Scheduling scheduling) => new SchedulingVm()
    {
        Id = scheduling.Id,
        Attendance = scheduling.Attendance.ToVm(),
        DateInitial = scheduling.DateInitial,
        DateEnd = scheduling.DateEnd,
        Description = scheduling.Description
    };
    
    public static IEnumerable<SchedulingVm> ToVm(this IEnumerable<Scheduling> schedulings) => 
        schedulings.Select(scheduling => scheduling.ToVm());
}
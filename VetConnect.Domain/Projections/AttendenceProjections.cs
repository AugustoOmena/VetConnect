using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Attendance;
using VetConnect.Domain.ViewModels.Pets;

namespace VetConnect.Domain.Projections;

public static class AttendenceProjections
{
    public static AttendanceVm ToVm(this Attendance attendance) => new AttendanceVm()
    {
        Id = attendance.Id,
        AppointmentId = attendance.AppointmentId,
        AttendanceStatus = attendance.AttendanceStatus,
        AgentId = attendance.AgentId,
        CreatedAt = attendance.DateCreated.UtcDateTime,
        Data = attendance.Data
    };
    
    public static IEnumerable<AttendanceVm> ToVm(this IEnumerable<Attendance> attendences) => 
        attendences.Select(attendance => attendance.ToVm());
}
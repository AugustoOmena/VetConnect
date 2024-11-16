using VetConnect.Domain.Entities;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IAttendance: IRepository<Attendance>
{
    Task<T> AddAttendanceAsync<T>(T attendance);
    
    // Expression<Func<Attendance, bool>> Where(AttendanceByUserQuery query);
}
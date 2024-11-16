using System.Linq.Expressions;
using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Shared.Utils;

namespace VetConnect.Data.Repositories;

public class AttendanceRepository: Repository<Attendance>, IAttendance
{
    public AttendanceRepository(DataContext context)
        : base(context)
    {
    }

    public async Task<T> AddAttendanceAsync<T>(T attendance)
    {
        await _context.AddAsync(attendance);
        return attendance;
    }
    
}
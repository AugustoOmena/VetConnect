using System.Linq.Expressions;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IScheduling: IRepository<Scheduling>
{
    Task<T> AddSchedulingAsync<T>(T pet);
    
    Expression<Func<Scheduling, bool>> Where(SchedulingByUserQuery query);
    
}
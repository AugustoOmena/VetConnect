using VetConnect.Shared.Persistence;
using System.Linq.Expressions;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Filters;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Expression<Func<User, bool>> Where(ListUserFilter filter);
    Task<T> AddUserAsync<T>(T user);
}
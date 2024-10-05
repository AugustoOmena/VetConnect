using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Shared.Persistence;
using System.Linq.Expressions;
using ClinicManagementSystem.Domain.Filters;

namespace ClinicManagementSystem.Domain.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Expression<Func<User, bool>> Where(UserFilter filter);
    Task<T> AddUserAsync<T>(T user);
}
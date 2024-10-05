using System.Linq.Expressions;
using ClinicManagementSystem.Data.Utils;
using ClinicManagementSystem.Domain.Contracts.Repositories;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Filters;
using ClinicManagementSystem.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Data.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataContext context)
        : base(context)
    {
    }

    public Expression<Func<User, bool>> Where(UserFilter filter)
    {
        var predicate = PredicateBuilder.True<User>();
            
        predicate = string.IsNullOrWhiteSpace(filter.Name)
            ? predicate
            : predicate.And(x => EF.Functions.Like(x.Name .ToLower(), $"%{filter.Name.ToLower()}%"));

        predicate = string.IsNullOrWhiteSpace(filter.Email)
            ? predicate
            : predicate.And(x => x.Email.ToLower() == filter.Email.ToLower());
            
        return predicate;
    }
        
    public async Task<User> FindByEmailAsync(string email) => 
        await _context.Set<User>().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

    public async Task<T> AddUserAsync<T>(T user)
    {
        await _context.AddAsync(user);
        return user;
    }
}
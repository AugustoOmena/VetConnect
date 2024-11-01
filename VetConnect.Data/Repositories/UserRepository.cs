using System.Linq.Expressions;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Filters;
using VetConnect.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using VetConnect.Data.Utils;

namespace VetConnect.Data.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataContext context)
        : base(context)
    {
    }

    public Expression<Func<User, bool>> Where(ListUserFilter filter)
    {
        var predicate = PredicateBuilder.True<User>();
            
        predicate = string.IsNullOrWhiteSpace(filter.FirstName)
            ? predicate
            : predicate.And(x => EF.Functions.Like(x.FirstName .ToLower(), $"%{filter.FirstName.ToLower()}%"));

        predicate = string.IsNullOrWhiteSpace(filter.LastName)
            ? predicate
            : predicate.And(x => EF.Functions.Like(x.LastName .ToLower(), $"%{filter.LastName.ToLower()}%"));

        
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
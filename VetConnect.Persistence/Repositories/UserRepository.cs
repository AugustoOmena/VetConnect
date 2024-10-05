using Microsoft.EntityFrameworkCore;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Interfaces;
using VetConnect.Persistence.Context;

namespace VetConnect.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken) ?? throw new InvalidOperationException();
    }
}
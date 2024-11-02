using Microsoft.EntityFrameworkCore;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Interfaces;
using VetConnect.Persistence.Context;

namespace VetConnect.Persistence.Repositories;

public class ServiceRepository: BaseRepository<ServiceHistory>, IServiceHistoryRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ServiceHistory> GetByName(string name, CancellationToken cancellationToken)
    {
        return await Context.ServiceHistories.FirstOrDefaultAsync(x => x.Name == name, cancellationToken) ?? throw new InvalidOperationException();
    }
}
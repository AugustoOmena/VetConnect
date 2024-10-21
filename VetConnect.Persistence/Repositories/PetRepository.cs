using Microsoft.EntityFrameworkCore;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Interfaces;
using VetConnect.Persistence.Context;

namespace VetConnect.Persistence.Repositories;

public class PetRepository: BaseRepository<Pet>, IPetRepository
{
    public PetRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Pet> GetByName(string name, CancellationToken cancellationToken)
    {
        return await Context.Pets.FirstOrDefaultAsync(x => x.Name == name, cancellationToken) ?? throw new InvalidOperationException();
    }
}
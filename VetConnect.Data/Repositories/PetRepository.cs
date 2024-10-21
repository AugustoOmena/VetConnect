using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;

namespace VetConnect.Data.Repositories;

public class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(DataContext context)
        : base(context)
    {
    }

    public Task<T> AddPetAsync<T>(T pet)
    {
        throw new NotImplementedException();
    }
}
using System.Linq.Expressions;
using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Utils;

namespace VetConnect.Data.Repositories;

public class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(DataContext context)
        : base(context)
    {
    }

    public async Task<T> AddPetAsync<T>(T pet)
    {
        await _context.AddAsync(pet);
        return pet;
    }

    public Expression<Func<Pet, bool>> Where(PetsByUserQuery query)
    {
        var predicate = PredicateBuilder.True<Pet>();
        
        predicate = (query.Filter.Name == null)
            ? predicate
            : predicate.And(x => x.Name.ToLower().Contains(query.Filter.Name.ToLower()));
        
        predicate = (query.Filter.StartAgeDate == null)
            ? predicate
            : predicate.And(x => x.BirthDate >= query.Filter.StartAgeDate);
    
        predicate = (query.Filter.EndAgeDate == null)
            ? predicate
            : predicate.And(x => x.BirthDate <= query.Filter.EndAgeDate);
        
        return predicate;
    }
}
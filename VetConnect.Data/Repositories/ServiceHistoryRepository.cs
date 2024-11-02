using System.Linq.Expressions;
using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Utils;

namespace VetConnect.Data.Repositories;

public class ServiceHistoryRepository: Repository<ServiceHistory>, IServiceHistoryRepository
{
    public ServiceHistoryRepository(DataContext context)
        : base(context)
    {
    }

    public async Task<T> AddServiceAsync<T>(T service)
    {
        await _context.AddAsync(service);
        return service;
    }

    public Expression<Func<Pet, bool>> Where(PetsByUserQuery query)
    {
        var predicate = PredicateBuilder.True<Pet>();

        predicate = predicate.And(x => x.DateDeleted == null);

        predicate = predicate.And(x => x.UserId == query.SessionUser.Id);
        
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
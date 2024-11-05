using System.Linq.Expressions;
using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Filters;
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

    public Expression<Func<ServiceHistory, bool>> Where(ListServicesHistoryFilter filter)
    {
        var predicate = PredicateBuilder.True<ServiceHistory>();

        predicate = predicate.And(x => x.DateDeleted == null);
        
        predicate = (filter.Name == null)
            ? predicate
            : predicate.And(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
      
        predicate = (filter.Description == null)
            ? predicate
            : predicate.And(x => x.Description.ToLower().Contains(filter.Description.ToLower()));
        
        predicate = (filter.Pet.Name == null)
            ? predicate
            : predicate.And(x => x.Pet.Name.ToLower().Contains(filter.Pet.Name.ToLower()));

        predicate = (filter.Pet.User.FirstName == null)
            ? predicate
            : predicate.And(x => (x.Pet.User.FirstName.ToLower() + " " + x.Pet.User.LastName.ToLower()).Contains(filter.Pet.User.FirstName.ToLower()));
        
        predicate = (filter.LowestPrice != 0 && filter.LowestPrice > 0)
            ? predicate.And(x => x.Price >= filter.LowestPrice)
            : predicate;
    
        predicate = (filter.HighestPrice != 0 && filter.HighestPrice > 0)
            ? predicate.And(x => x.Price <= filter.HighestPrice)
            : predicate;
        
        return predicate;
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
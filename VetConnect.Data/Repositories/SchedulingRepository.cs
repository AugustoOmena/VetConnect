using System.Linq.Expressions;
using VetConnect.Data.Utils;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Utils;

namespace VetConnect.Data.Repositories;

public class SchedulingRepository: Repository<Scheduling>, IScheduling
{
    public SchedulingRepository(DataContext context)
        : base(context)
    {
    }

    public async Task<T> AddSchedulingAsync<T>(T scheduling)
    {
        await _context.AddAsync(scheduling);
        return scheduling;
    }

    public Expression<Func<Scheduling, bool>> Where(SchedulingByUserQuery query)
    {
        var predicate = PredicateBuilder.True<Scheduling>();

        predicate = predicate.And(x => x.DateDeleted == null);

        if (query.SessionUser.UserType == EUserType.Cliente)
        {
            predicate = predicate.And(x => x.Pet.UserId == query.SessionUser.Id);
        }
        
        predicate = (query.Filter.Description == null)
            ? predicate
            : predicate.And(x => x.Description.ToLower().Contains(query.Filter.Description.ToLower()));
        
        predicate = (query.Filter.StartDate == null)
            ? predicate
            : predicate.And(x => x.DateInitial >= query.Filter.StartDate);
    
        predicate = (query.Filter.EndDate == null)
            ? predicate
            : predicate.And(x => x.DateEnd <= query.Filter.EndDate);
        
        return predicate;
    }

    public Expression<Func<Scheduling, bool>> Where(ListPetsByUserIdQuery query)
    {
        var predicate = PredicateBuilder.True<Scheduling>();

        predicate = (query.Id == null)
            ? predicate
            : predicate.And(x => x.Pet.UserId == query.Id);
        
        return predicate;
    }
    
}
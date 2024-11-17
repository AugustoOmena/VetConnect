using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Users;
using VetConnect.Domain.ViewModels.Scheduling;
using VetConnect.Domain.Projections;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.QueryHandlers;

public class SchedulingQueryHandler : BaseQueryHandler,
    IRequestHandler<SchedulingByUserQuery, PagedList<SchedulingVm>>
{
    private readonly IScheduling _scheduling;
    private readonly IUserRepository _userRepository;
    
    public SchedulingQueryHandler(IDomainNotification notifications, IScheduling scheduling, IUserRepository user, IUserRepository userRepository) : base(notifications)
    {
        _scheduling = scheduling;
        _userRepository = userRepository;
    }

    public async Task<PagedList<SchedulingVm>> Handle(SchedulingByUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id == query.SessionUser.Id && x.DateDeleted == null);

        if (user is null)
        {
            throw new InvalidOperationException("Usuário não encontrado.");
        }

        query.SessionUser.UserType = user.UserType;

        var where = _scheduling.Where(query);
            
        var count = await _scheduling.CountAsync(where);
        
        var includes = new IncludeHelper<Scheduling>()
            .Include(x => x.Attendance)
            .Include(x => x.Pet)
            .Include(x => x.Pet.User)
            .Include(x => x.ServiceHistory)
            .Includes;
        
        var scheduling = _scheduling
            .ListAsNoTracking(where, query.Filter, includes)
            .ToVm();
        
        return new PagedList<SchedulingVm>(scheduling, count, query.Filter.PageSize);
    }
}
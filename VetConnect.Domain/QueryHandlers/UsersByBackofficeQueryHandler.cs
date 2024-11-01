using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Domain.ViewModels.Users;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;

namespace VetConnect.Domain.QueryHandlers;

public class UsersByBackofficeQueryHandler : BaseQueryHandler,
    IRequestHandler<UsersByBackofficeQuery, PagedList<UserVm>>

{
    private readonly IUserRepository _userRepository;
    
    public UsersByBackofficeQueryHandler(IDomainNotification notifications, IUserRepository userRepository) : base(notifications)
    {
        _userRepository = userRepository;
    }

    public async Task<PagedList<UserVm>> Handle(UsersByBackofficeQuery query, CancellationToken cancellationToken)
    {
        // Solução provisória, o ideal é buscar o tipo de usuário por Claim
        var sessionUser = await _userRepository.FindAsync(x => x.Id == query.SessionUser.Id && x.DateDeleted == null);

        if (sessionUser.UserType is not (EUserType.BackOffice or EUserType.Admin) )
        {
            Notifications.Handle("Usuário não tem autorização.");
            return null;
        }
        
        var where = _userRepository.Where(query.Filter);
            
        var count = await _userRepository.CountAsync(where);
        
        var users = _userRepository
            .ListAsNoTracking(where, query.Filter)
            .ToVm();
        
        return new PagedList<UserVm>(users, count, query.Filter.PageSize);
    }
}
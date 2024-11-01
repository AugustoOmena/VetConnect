using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Domain.ViewModels.Users;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.QueryHandlers;

public class UsersByBackofficeQueryHandler : BaseQueryHandler,
    IRequestHandler<UsersByBackofficeQuery, PagedList<UserVm>>,
    IRequestHandler<UserByBackofficeQuery, UserVm>,
    IRequestHandler<PetByIdBackofficeQuery, PetVm>

{
    private readonly IUserRepository _userRepository;
    private readonly IPetRepository _petRepository;
    
    public UsersByBackofficeQueryHandler(IDomainNotification notifications, IUserRepository userRepository, IPetRepository petRepository) : base(notifications)
    {
        _userRepository = userRepository;
        _petRepository = petRepository;
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

    public async Task<UserVm> Handle(UserByBackofficeQuery query, CancellationToken cancellationToken)
    {
        var includes = new IncludeHelper<User>()
            .Include(x => x.Pets)
            .Includes;
        
        var result = await _userRepository
            .FindAsync(x => x.Id == query.Id && x.DateDeleted == null, includes);
        
        return result.ToVm();
    }

    public async Task<PetVm> Handle(PetByIdBackofficeQuery query, CancellationToken cancellationToken)
    {
        var includes = new IncludeHelper<Pet>()
            .Includes;
        
        var result = await _petRepository
            .FindAsync(x => x.Id == query.Id && x.DateDeleted == null, includes);
        
        return result.ToVm();
    }
}
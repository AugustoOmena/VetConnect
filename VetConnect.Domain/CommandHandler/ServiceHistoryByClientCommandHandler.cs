using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Users;
using VetConnect.Domain.ViewModels.Services;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Persistence;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.CommandHandler;

public class ServiceHistoryByClientCommandHandler: BaseCommandHandler,
    IRequestHandler<ListServiceHistoryToUserQuery, PagedList<ServiceHistoryVm>>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IServiceHistoryRepository _serviceHistoryRepository;
    
    public ServiceHistoryByClientCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository, IServiceHistoryRepository serviceHistoryRepository) : base(uow, notifications)
    {
        _userRepository = userRepository;
        _serviceHistoryRepository = serviceHistoryRepository;
    }

    public async Task<PagedList<ServiceHistoryVm>> Handle(ListServiceHistoryToUserQuery query, CancellationToken cancellationToken)
    {
        var where = _serviceHistoryRepository.Where(query.Filter);
        
        var includes = new IncludeHelper<ServiceHistory>()
            .Includes;
        
        var count = _serviceHistoryRepository.ListAsNoTracking(where, query.Filter, includes);
        
        var services = _serviceHistoryRepository
            .ListAsNoTracking(where, query.Filter, includes)
            .ToVm();
        
        return new PagedList<ServiceHistoryVm>(services, count.Count(), query.Filter.PageSize);
    }
}
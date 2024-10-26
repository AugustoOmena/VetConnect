using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Users;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.QueryHandlers;

public class PetsByUsersQueryHandler : BaseQueryHandler,
    IRequestHandler<PetsByUserQuery, PagedList<PetVm>>
{
    private readonly IPetRepository _petRepository;
        
    public PetsByUsersQueryHandler(IDomainNotification notifications, IPetRepository petRepository) : base(notifications)
    {
        _petRepository = petRepository;
    }

    public async Task<PagedList<PetVm>> Handle(PetsByUserQuery query, CancellationToken cancellationToken)
    {
        var where = _petRepository.Where(query);
            
        var includes = new IncludeHelper<Pet>()
            .Include(x => x.User)
            .Includes;
            
        var count = await _petRepository.CountAsync(where);
        
        var pets = _petRepository
            .ListAsNoTracking(where, query.Filter, includes)
            .ToVm();
        
        return new PagedList<PetVm>(pets, count, query.Filter.PageSize);
    }
}
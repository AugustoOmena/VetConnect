using MediatR;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Projections;
using VetConnect.Domain.Queries.Users;
using VetConnect.Domain.ViewModels.Pets;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Utils;

namespace VetConnect.Domain.QueryHandlers;

public class PetsByUsersQueryHandler : BaseQueryHandler,
    IRequestHandler<PetsByUserQuery, PagedList<PetVm>>
{
    private readonly IPetRepository _petRepository;
    private readonly IUserRepository _userRepository;
        
    public PetsByUsersQueryHandler(IDomainNotification notifications, IPetRepository petRepository, IUserRepository userRepository) : base(notifications)
    {
        _petRepository = petRepository;
        _userRepository = userRepository;
    }

    public async Task<PagedList<PetVm>> Handle(PetsByUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id == query.SessionUser.Id && x.DateDeleted == null);
        
        // Caso o usuário logado exista e tenha acesso ao backoffice, então removo o filtro por id de usuário logado removendo
        // o userType.
        if (user is null)
        {
            throw new ArgumentException("Usuário não encontrado ou não autorizado.");
        }
        
        if (user.UserType != EUserType.Cliente)
        {
            query.SessionUser.UserType = null;
        }
        else
        {
            query.SessionUser.UserType = user.UserType;
        }
        //end
        
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
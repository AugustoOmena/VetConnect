using VetConnect.Domain.Entities;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IServiceHistoryRepository: IRepository<ServiceHistory>
{
    Task<T> AddServiceAsync<T>(T service);
    
    //Expression<Func<Pet, bool>> Where(PetsByUserQuery query);

}
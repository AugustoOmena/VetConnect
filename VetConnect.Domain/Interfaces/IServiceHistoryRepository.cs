using VetConnect.Domain.Entities;

namespace VetConnect.Domain.Interfaces;

public interface IServiceHistoryRepository: IBaseRepository<ServiceHistory>
{
    Task<ServiceHistory> GetByName(string email, CancellationToken cancellationToken);
}
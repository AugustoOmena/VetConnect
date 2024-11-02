using System.Linq.Expressions;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Filters;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IServiceHistoryRepository: IRepository<ServiceHistory>
{
    Task<T> AddServiceAsync<T>(T service);
    
    Expression<Func<ServiceHistory, bool>> Where(ListServicesHistoryFilter query);

}
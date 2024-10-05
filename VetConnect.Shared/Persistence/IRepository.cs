using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetConnect.Shared.Paging;

namespace VetConnect.Shared.Persistence
{
    public interface IRepository<T>
        where T : class
    {
        
        Task<T> FindAsync(Expression<Func<T, bool>> where);
        Task AddAsync(T entity);
        void Modify(T entity);
        void Remove(T entity);
        
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        IQueryable<T> List(Expression<Func<T, bool>> where = null, IPagination pagination = null);
        
        
        //PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination);
    }
}
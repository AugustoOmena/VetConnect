using System.Linq.Expressions;
using VetConnect.Shared.Paging;

namespace VetConnect.Shared.Persistence
{
    public interface IRepository<T>
        where T : class
    {
        
        Task<T> FindAsync(Expression<Func<T, bool>> where);
        Task<T> FindAsync(Expression<Func<T, bool>> where,
            IEnumerable<string> includes = null);
        Task AddAsync(T entity);
        void Modify(T entity);
        void Remove(T entity);
        
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        IQueryable<T> List(Expression<Func<T, bool>> where = null, IPagination pagination = null);
        
        IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where,
            IPagination pagination,
            IEnumerable<string> includes = null);
        
        //PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination);
    }
}
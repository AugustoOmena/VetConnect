using System.Linq.Expressions;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using VetConnect.Data.Utils;

namespace VetConnect.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly string _connStr;

        public DbSet<T> DbSet => _context.Set<T>();

        public Repository(DataContext context)
        {
            _context = context;
            _connStr = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.FirstOrDefaultAsync(where);
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Modify(T entity)
        {
            DbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            return where == null ? await DbSet.CountAsync() : await DbSet.CountAsync(where);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> where = null, IPagination pagination = null)
        {
            IQueryable<T> query = where == null ? DbSet : DbSet.Where(where);
            
            if (pagination != null)
            {
                query = query.Skip((pagination.PageIndex - 1) * pagination.PageSize)
                             .Take(pagination.PageSize);
            }

            return query;
        }

        // public PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination)
        // {
        //     var query = List(where, pagination);
        //     return new PagedList<T>(query.ToList(), Count(where), pagination.PageIndex, pagination.PageSize);
        // }
    }
}

using System.Linq.Expressions;
using VetConnect.Shared.Paging;
using VetConnect.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using VetConnect.Data.Utils;
using System.Linq.Dynamic.Core;

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
        
        public IQueryable<T> Find(IEnumerable<string> includes = null)
        {
            IQueryable<T> currentSet = _context.Set<T>();

            if (includes != null)
            {
                currentSet = includes.Where(include => !string.IsNullOrEmpty(include))
                    .Aggregate(currentSet, (current, include) => current.Include(include));
            }

            return currentSet;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where, ICollection<string> includes)
        {
            return await DbSet.FirstOrDefaultAsync(where);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.FirstOrDefaultAsync(where);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where, IEnumerable<string> includes = null)
        {
            IQueryable<T> currentSet = Find(includes);

            var entity = await currentSet.FirstOrDefaultAsync(where);

            return entity;
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
        
        private IQueryable<T> CurrentSet(Expression<Func<T, bool>> where = null, int? page = null,
            int? PageSize = null,
            string SortField = null, string SortType = null, IEnumerable<string> includes = null)
        {
            IQueryable<T> currentSet = _context.Set<T>();

            where ??= (x => true);

            if (includes != null)
            {
                currentSet = includes.Where(include => !string.IsNullOrEmpty(include))
                    .Aggregate(currentSet, (current, include) => current.Include(include));
            }

            currentSet = currentSet.Where(where);

            if (!string.IsNullOrEmpty(SortField) && !string.IsNullOrEmpty(SortType))
            {
                currentSet = currentSet.OrderBy(SortField + " " + SortType);
            }

            if (page != null && PageSize != null)
            {
                currentSet = currentSet
                    .Skip((page.Value - 1) * PageSize.Value)
                    .Take(PageSize.Value);
            }

            return currentSet;
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
        
        public IQueryable<T> List(Expression<Func<T, bool>> where, IPagination pagination,
            IEnumerable<string> includes = null)
        {
            return CurrentSet(where, pagination.PageIndex, pagination.PageSize, pagination.SortField,
                pagination.SortType, includes);
        }
        
        public IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination,
            IEnumerable<string> includes = null)
        {
            return List(where, pagination, includes).AsNoTracking();
        }

        // public PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination)
        // {
        //     var query = List(where, pagination);
        //     return new PagedList<T>(query.ToList(), Count(where), pagination.PageIndex, pagination.PageSize);
        // }
    }
}

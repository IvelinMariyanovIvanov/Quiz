using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Quiz.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly QuizDbContext _context;

        private DbSet<T> _currentDbTable;

        public BaseRepository(QuizDbContext context)
        {
            _context = context;
            _currentDbTable = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _currentDbTable.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _currentDbTable.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _currentDbTable.RemoveRange(entities);
        }


        public async Task<List<T>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<T> data = _currentDbTable;

            if (includeProperties != null)
            {
                foreach (string prop in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    data = data.Include(prop);
                }
            }

            return await data.ToListAsync();
        }

        public IQueryable<T> GetAllWithLinqAsyncAsIQueryable
            (Expression<Func<T, bool>>? linqExpression, string? includeTables = null)
        {
            IQueryable<T> data = _currentDbTable;

            if (linqExpression != null)
                data = data.Where(linqExpression);

            if (includeTables != null)
            {
                foreach (string prop in includeTables.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    data = data.Include(prop);
                }
            }

            return data.AsNoTracking();
        }

        public async Task<T?> GetEntityAsync(Expression<Func<T, bool>> linqExpression, string? includeProperties = null)
        {
            IQueryable<T> data = _currentDbTable.Where(linqExpression);

            if (includeProperties != null)
            {
                foreach (string prop in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    data = data.Include(prop);
                }
            }

            return await data.FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(int? id, string? includeProperties = null)
        {
            DbSet<T> data = _currentDbTable;

            if (includeProperties != null)
            {
                foreach (string prop in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    data = (DbSet<T>)data.Include(prop);
                }
            }

            return await data.FindAsync(id);
        }
    }
}

using System.Linq.Expressions;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string? includeTables = null);

        IQueryable<T> GetAllWithLinqAsyncAsIQueryable
            (Expression<Func<T, bool>>? linqExpression, string? includeTables = null);

        // Get a single entity with linq expression
        Task<T?> GetEntityAsync(Expression<Func<T, bool>> linqExpression, string? includeTables = null);

        // Get a single entity by PK
        Task<T?> GetByIdAsync(int? id, string? includeTables = null);

        Task AddAsync(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
    }
}

using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>
    where TEntity : BaseEntity<TEntityId>
{

    Task<List<TEntity>> GetAllAsync
        (Expression<Func<TEntity, bool>> predicate = null,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);

}

namespace Grocery.Infrastructure;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TKey id);
}
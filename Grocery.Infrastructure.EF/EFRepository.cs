using Microsoft.EntityFrameworkCore;

namespace Grocery.Infrastructure.EF;

public class EFRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity:class, IEntity<TKey>,new()
{
    private readonly DbContext _dbcontext;
    private readonly DbSet<TEntity> _set;

    public EFRepository(DbContext _dbcontext)
    {
        this._dbcontext = _dbcontext;
        _set = _dbcontext.Set<TEntity>();
    }
    public IQueryable<TEntity> GetAll()
    {
        return _set.AsNoTracking();
    }

    public Task<TEntity?> GetByIdAsync(TKey id)
    {
        return _set.FindAsync(id).AsTask();
    }

    public async Task Create(TEntity entity)
    {
         _set.Add(entity);
         await _dbcontext.SaveChangesAsync();
        _dbcontext.Entry(entity).State = EntityState.Detached;
    }

    public async Task Update(TEntity entity)
    {
        _set.Update(entity);
        await _dbcontext.SaveChangesAsync();
        _dbcontext.Entry(entity).State = EntityState.Detached;
    }

    public Task Delete(TKey id)
    {
        var entity = new TEntity()
        {
            Id = id
        };
            
        _set.Remove(entity);
        return _dbcontext.SaveChangesAsync();
    }
}
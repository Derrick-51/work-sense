using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public interface ICRUDService<TEntity, TKey>
{
    public Task<ServiceResult<List<TEntity>>> GetAll();
    public Task<ServiceResult<TEntity>> GetByKey(TKey key);
    public Task<ServiceResult<TEntity>> Post(TEntity entity);
    public Task<ServiceResult<TEntity>> Put(TEntity entity);
    public Task<IServiceResult> Delete(long id);
}
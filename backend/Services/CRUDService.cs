using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public class CRUDService<TEntity, TKey> where TEntity : BaseModel<TEntity,TKey>, new()
{
    protected readonly AppDbContext DbContext;

    public CRUDService(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    //
    // GET ALL
    //
    public virtual async Task<ServiceResult<List<TEntity>>> GetAll()
    {
        List<TEntity> entities = await DbContext
            .GetCollection<TEntity>()
            .ToListAsync();

        if (entities.Count == 0)
        {
            return ServiceResult<List<TEntity>>.Failure(ResultError.NotFound, "No departments found");
        }

        return ServiceResult<List<TEntity>>.Success(entities);
    }

    //
    // GET BY ID
    //
    public virtual async Task<ServiceResult<TEntity>> GetByKey(TKey key)
    {
        // Null when not found
        TEntity? entity = await DbContext
            .GetCollection<TEntity>()
            .FindAsync(key);

        if (entity is null)
        {
            return ServiceResult<TEntity>
                .Failure(ResultError.NotFound
                    , $"{nameof(TEntity)} with key: {key} not found");
        }

        return ServiceResult<TEntity>.Success(entity);
    }

    //
    // POST
    //
    public virtual async Task<ServiceResult<TEntity>> Post(TEntity entity)
    {
        TEntity newEntity = new TEntity();
        newEntity.UpdateFieldsUsing(entity);

        // Store and return new entity
        EntityEntry<TEntity> newEntityEntry = await DbContext
            .GetCollection<TEntity>()
            .AddAsync(newEntity);
        await DbContext.SaveChangesAsync();

        TEntity createdEntity = new TEntity();
        createdEntity.UpdateFieldsUsing(newEntityEntry.Entity);

        return ServiceResult<TEntity>.Success(createdEntity);
    }

    //
    // PUT
    //
    public virtual async Task<ServiceResult<TEntity>> Put(TEntity entity)
    {
        TEntity? existingEntity = await DbContext
            .GetCollection<TEntity>()
            .FindAsync(entity.Key);

        if (existingEntity is null)
        {
            return ServiceResult<TEntity>
                .Failure(ResultError.NotFound
                    , $"{typeof(TEntity).Name} with key: {entity.Key} not found.");
        }

        existingEntity.UpdateFieldsUsing(entity);
        await DbContext.SaveChangesAsync();

        return ServiceResult<TEntity>.Success(existingEntity);
    }

    //
    // DELETE
    //
    public virtual async Task<IServiceResult> Delete(TKey key)
    {
        if (key is null)
            return ServiceResult.Failure(ResultError.BadRequest, "Null key argument");

        await DbContext.GetCollection<TEntity>()
            .Where(e => key.Equals(e.Key))
            .ExecuteDeleteAsync();

        return ServiceResult.Success();
    }
}
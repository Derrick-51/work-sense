using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WorkSense.Backend.Models;


public interface ITransferObject<TEntity, TKey, TTransferObject>
where TEntity : BaseModel<TEntity, TKey>, new()
{
    /// <summary>
    /// Provides access to parameterized DTO construction
    /// from a generic type parameter
    /// EXAMPLE:
    /// GenericService<T> where DTO : I
    /// {
    ///     T newT = new DTO(Entity) /* No interface contract CS0417 Error */
    ///     T newT = DTO.CreateDTO(Entity) /* Interface contract upheld */
    /// }
    /// </summary>
    /// <param name="entity">The complete entity that the
    ///     DTO is based on</param>
    /// <returns>Returns a Data Transfer Object constructed
    ///     with the given entity</returns>
    public static abstract TTransferObject CreateWithEntity(TEntity entity);

    /// <summary>
    /// Updates entity with DTO properties.
    /// Gives DTO responsibility of updating entity with
    ///     its custom properties.
    /// </summary>
    /// <param name="entity">The complete entity that the
    ///     DTO is based on</param>
    public abstract void UpdateEntity(TEntity entity);
}
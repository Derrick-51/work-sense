using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public interface IBaseModel<TEntity, TKey>
{
    public abstract void UpdateFieldsUsing(TEntity entity);
}
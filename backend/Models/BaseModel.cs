using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WorkSense.Backend.Models;

public abstract class BaseModel<TEntity, TKey> : IBaseModel<TEntity, TKey>
{
    [Key]
    public TKey? Key { get; set; }

    public abstract void UpdateFieldsUsing(TEntity entity);
}
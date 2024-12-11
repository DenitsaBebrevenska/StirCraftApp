using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Base entity class for all entities
/// </summary>
public abstract class BaseEntity : ISoftDeletable
{
    /// <summary>
    /// The unique identifier for an entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// A flag indicating if this entity is deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// The date and time UTC this entity was deleted
    /// </summary>
    public DateTime? DeletedOnUtc { get; set; }
}

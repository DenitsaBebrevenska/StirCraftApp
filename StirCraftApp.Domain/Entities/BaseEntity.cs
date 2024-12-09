using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public abstract class BaseEntity : ISoftDeletable
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}

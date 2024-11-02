using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public abstract class BaseEntity : ISoftDeletable
{
    //todo should my repo and other classes implement base entity, the only problem with that is if I need to use AppUser on them
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}

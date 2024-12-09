namespace StirCraftApp.Domain.Contracts;
public interface ISoftDeletable
{
    bool IsDeleted { get; set; }

    DateTime? DeletedOnUtc { get; set; }

}

using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public abstract class BaseEntity : ISoftDeletable
{
	public int Id { get; set; }

	//Might be useful to have created on and updated on as base props
	public bool IsDeleted { get; set; }
	public DateTime? DeletedOnUtc { get; set; }
}

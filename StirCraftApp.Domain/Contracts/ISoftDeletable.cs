namespace StirCraftApp.Domain.Contracts;
public interface ISoftDeletable
{
	bool IsDeleted { get; set; }

	int IsDeletedBy { get; set; }

	public void Undo()
	{
		IsDeleted = false;
		IsDeletedBy = default;
	}
}

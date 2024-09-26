namespace StirCraftApp.Domain.Entities;
public class Ingredient : BaseEntity
{
	public required string Name { get; set; }

	public bool IsAllergen { get; set; }

	public bool IsVegan { get; set; }

}

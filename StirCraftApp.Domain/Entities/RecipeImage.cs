using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity
{
	[MaxLength(ImageUrlMaxLength)]
	public required string Url { get; set; }

	public int RecipeId { get; set; }

	public virtual required Recipe Recipe { get; set; }
}

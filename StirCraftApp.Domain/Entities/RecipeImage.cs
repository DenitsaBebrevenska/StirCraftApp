using StirCraftApp.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity, ISoftDeletable
{
	[MaxLength(ImageUrlMaxLength)]
	public required string Url { get; set; }

	public int RecipeId { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}

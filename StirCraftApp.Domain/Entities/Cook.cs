using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

public class Cook : BaseEntity
{
	public int UserId { get; set; }

	[MaxLength(CookAboutMaxLength)]
	public required string About { get; set; }

	public uint RankingPoints { get; set; }

	public required CookingRank Rank { get; set; }

	public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}

using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Domain.Entities;
using static Constraints.EntityConstraints;

public class Cook : BaseEntity
{
	public required string UserId { get; set; }

	[MaxLength(CookAboutMaxLength)]
	public required string About { get; set; }

	public uint RankingPoints { get; set; }

	public int CookingRankId { get; set; }

	public virtual required CookingRank CookingRank { get; set; }

	public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}

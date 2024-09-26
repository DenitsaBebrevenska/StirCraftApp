using StirCraftApp.Domain.Enums;

namespace StirCraftApp.Domain.Entities;
public class Cook : BaseEntity
{
	public int UserId { get; set; }

	public required string About { get; set; }

	public int RankingPoints { get; set; }

	public Rank Rank { get; set; }

}

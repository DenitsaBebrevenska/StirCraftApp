using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities
{
	public class CookingRank : BaseEntity
	{
		[MaxLength(RankTitleMaxLength)]
		public required string Title { get; set; }

		public uint RequiredPoints { get; set; }

		public virtual ICollection<Cook> CooksWithThatRank { get; set; } = new List<Cook>();
	}
}

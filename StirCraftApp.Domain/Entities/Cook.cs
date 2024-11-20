using StirCraftApp.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Domain.Entities;
using static EntityConstraints;

public class Cook : BaseEntity
{
    public required string UserId { get; set; }

    [MaxLength(CookAboutMaxLength)]
    public required string About { get; set; }

    public uint RankingPoints { get; set; }

    public int CookingRankId { get; set; }

    public virtual CookingRank CookingRank { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}

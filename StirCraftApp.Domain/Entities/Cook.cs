using StirCraftApp.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Domain.Entities;
using static EntityConstraints;

public class Cook : BaseEntity
{
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;


    [MaxLength(CookAboutMaxLength)]
    public required string About { get; set; }

    public int RankingPoints { get; set; }

    [ForeignKey(nameof(CookingRank))]
    public int CookingRankId { get; set; }

    public virtual CookingRank CookingRank { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}

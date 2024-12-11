using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a cook entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Cook : BaseEntity
{
    /// <summary>
    /// The unique identifier for the user that is a cook
    /// </summary>
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    /// <summary>
    /// A navigational property to the user that is a cook
    /// </summary>
    public virtual AppUser AppUser { get; set; } = null!;

    /// <summary>
    /// A brief description about the cook
    /// </summary>
    [MaxLength(CookAboutMaxLength)]
    public required string About { get; set; }

    /// <summary>
    /// The ranking points of the cook
    /// </summary>
    public int RankingPoints { get; set; }

    /// <summary>
    /// The unique identifier for the cooking rank the cook has
    /// </summary>
    [ForeignKey(nameof(CookingRank))]
    public int CookingRankId { get; set; }

    /// <summary>
    /// A navigational property to the cooking rank the user has
    /// </summary>
    public virtual CookingRank CookingRank { get; set; } = null!;

    /// <summary>
    /// A collection of recipes the cook has made
    /// </summary>
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}

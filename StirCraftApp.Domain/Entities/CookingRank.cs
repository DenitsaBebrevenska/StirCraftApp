using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a cooking rank entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class CookingRank : BaseEntity
{
    /// <summary>
    /// The title of the cooking rank
    /// </summary>
    [MaxLength(RankTitleMaxLength)]
    public required string Title { get; set; }

    /// <summary>
    /// The minimum required points to have this rank
    /// </summary>
    public int RequiredPoints { get; set; }

    /// <summary>
    /// A collection of all cooks who have that rank
    /// </summary>
    public virtual ICollection<Cook> CooksWithThatRank { get; set; } = new List<Cook>();
}


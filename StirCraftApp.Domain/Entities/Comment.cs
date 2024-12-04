using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Comment : BaseEntity
{
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    [MaxLength(CommentTitleMaxLength)]
    public required string Title { get; set; }

    [MaxLength(CommentBodyMaxLength)]
    public required string Body { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}

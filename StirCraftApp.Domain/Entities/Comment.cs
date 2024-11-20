using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Comment : BaseEntity
{
    public required string UserId { get; set; }

    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    [MaxLength(CommentTitleMaxLength)]
    public required string Title { get; set; }

    [MaxLength(CommentBodyMaxLength)]
    public required string Body { get; set; }
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}

using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity
{
    public required string UserId { get; set; }

    public int CommentId { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    [MaxLength(ReplyBodyMaxLength)]
    public required string Body { get; set; }
}

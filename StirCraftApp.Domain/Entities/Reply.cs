using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity
{
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    [ForeignKey(nameof(Comment))]
    public int CommentId { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    [MaxLength(ReplyBodyMaxLength)]
    public required string Body { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }
}

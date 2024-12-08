namespace StirCraftApp.Application.DTOs.ReplyDtos;
public class CommentReplyDto : BaseDto
{
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }

    public required string CreatedOn { get; set; }

    public string? UpdatedOn { get; set; }
}

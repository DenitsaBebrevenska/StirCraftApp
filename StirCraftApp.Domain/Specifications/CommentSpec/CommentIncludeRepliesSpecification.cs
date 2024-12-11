using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.CommentSpec;
public class CommentIncludeRepliesSpecification : BaseSpecification<Comment>
{
    public CommentIncludeRepliesSpecification()
    {
        AddInclude(c => c.Replies);
    }
}

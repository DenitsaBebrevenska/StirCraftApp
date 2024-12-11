using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeIncludedCommentsAndRepliesSpecification : BaseSpecification<Recipe>
{
    public RecipeIncludedCommentsAndRepliesSpecification()
    {
        AddInclude(r => r.Comments);
        AddIncludeStrings("Comments.Replies");
    }
}

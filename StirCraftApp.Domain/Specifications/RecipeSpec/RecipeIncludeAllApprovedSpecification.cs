using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeIncludeAllApprovedSpecification : BaseSpecification<Recipe>
{
    public RecipeIncludeAllApprovedSpecification() : base(r => r.IsAdminApproved == true)
    {
        AddInclude(r => r.Cook);
        AddInclude(r => r.Comments);
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeIngredients);
        AddInclude(r => r.CategoryRecipes);
        AddInclude(r => r.RecipeRatings);
        AddIncludeStrings("CategoryRecipes.Category");
        AddIncludeStrings("Comments.Replies");
        AddIncludeStrings("RecipeIngredients.Ingredient");
        AddIncludeStrings("RecipeIngredients.MeasurementUnit");
    }
}

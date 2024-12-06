using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipePendingApprovalSpecification : BaseSpecification<Recipe>
{
    public RecipePendingApprovalSpecification() : base(r => r.IsAdminApproved == false)
    {
        AddInclude(r => r.Cook);
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeIngredients);
        AddInclude(r => r.CategoryRecipes);
        AddIncludeStrings("CategoryRecipes.Category");
        AddIncludeStrings("RecipeIngredients.Ingredient");
        AddIncludeStrings("RecipeIngredients.MeasurementUnit");
    }
}

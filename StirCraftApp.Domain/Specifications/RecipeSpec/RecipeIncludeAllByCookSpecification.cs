using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeIncludeAllByCookSpecification : BaseSpecification<Recipe>
{
    public RecipeIncludeAllByCookSpecification(int cookId) : base(r => r.CookId == cookId)
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

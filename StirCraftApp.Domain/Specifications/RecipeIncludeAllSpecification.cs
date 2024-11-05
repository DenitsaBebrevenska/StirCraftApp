using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeIncludeAllSpecification : BaseSpecification<Recipe>
{
    public RecipeIncludeAllSpecification()
    {
        AddInclude(r => r.Cook);
        AddInclude(r => r.Comments);
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeIngredients);
        AddInclude(r => r.CategoryRecipes);
        AddIncludeStrings("CategoryRecipes.Category");
        AddIncludeStrings("Comments.Replies");
        AddIncludeStrings("RecipeIngredients.Ingredient");
        AddIncludeStrings("RecipeIngredients.MeasurementUnit");
    }
}

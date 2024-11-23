using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeByIngredientSpecification : BaseSpecification<Recipe>
{
    public RecipeByIngredientSpecification(int recipeId)
        : base(r => r.RecipeIngredients.Any(ri => ri.IngredientId == recipeId))
    {

    }
}

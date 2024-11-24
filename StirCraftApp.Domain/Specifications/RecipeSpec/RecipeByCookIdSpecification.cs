using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeByCookIdSpecification : BaseSpecification<Recipe>
{
    public RecipeByCookIdSpecification(int id) : base(r => r.CookId == id && r.IsAdminApproved == true)

    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.CategoryRecipes);
        AddInclude(r => r.RecipeRatings);
        AddIncludeStrings("CategoryRecipes.Category");
        AddOrderBy(r => r.CreatedOn);
    }
}

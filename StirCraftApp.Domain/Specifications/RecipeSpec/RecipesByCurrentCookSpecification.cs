using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipesByCurrentCookSpecification : BaseSpecification<Recipe>
{
    public RecipesByCurrentCookSpecification(PagingParams pagingParams, int cookId) : base(r => r.CookId == cookId)
    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.CategoryRecipes);
        AddInclude(r => r.RecipeRatings);
        AddIncludeStrings("CategoryRecipes.Category");
        AddOrderBy(r => r.CreatedOn);
        AddPaging(pagingParams.PageSize * (pagingParams.PageIndex - 1), pagingParams.PageSize);
    }
}

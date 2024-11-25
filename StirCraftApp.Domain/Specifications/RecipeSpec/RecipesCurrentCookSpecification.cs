using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipesCurrentCookSpecification : BaseSpecification<Recipe>
{
    public RecipesCurrentCookSpecification(int id, PagingParams paging) : base(r => r.CookId == id)
    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddOrderByDesc(r => r.CreatedOn);

        AddPaging(paging.PageSize * (paging.PageIndex - 1), paging.PageSize);
    }
}

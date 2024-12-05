using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeFavoritesSpecification : BaseSpecification<Recipe>
{
    public RecipeFavoritesSpecification(string userId, PagingParams pagingParams)
        : base(r => r.UserFavoriteRecipes.Any(fr => fr.UserId == userId && r.IsAdminApproved == true))
    {
        AddInclude(r => r.Cook);
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.UserFavoriteRecipes);

        AddOrderBy(r => r.Name);
        AddPaging(pagingParams.PageSize * (pagingParams.PageIndex - 1), pagingParams.PageSize);
    }
}

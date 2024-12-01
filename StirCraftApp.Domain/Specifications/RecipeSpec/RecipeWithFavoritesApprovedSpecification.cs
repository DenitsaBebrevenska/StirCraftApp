using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeWithFavoritesApprovedSpecification : BaseSpecification<Recipe>
{
    public RecipeWithFavoritesApprovedSpecification() : base(r => r.IsAdminApproved)
    {
        AddInclude(r => r.UserFavoriteRecipes);
    }
}

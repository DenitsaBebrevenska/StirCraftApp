using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeFavoritesApprovedSpecification : BaseSpecification<Recipe>
{
    public RecipeFavoritesApprovedSpecification()
        : base(r => r.IsAdminApproved)
    {
        AddInclude(r => r.UserFavoriteRecipes);
    }
}

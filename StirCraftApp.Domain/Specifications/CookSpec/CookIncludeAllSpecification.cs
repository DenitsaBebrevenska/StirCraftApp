using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.CookSpec;
public class CookIncludeAllSpecification : BaseSpecification<Cook>
{
    public CookIncludeAllSpecification()
    {
        AddInclude(c => c.CookingRank);
        AddInclude(c => c.Recipes);
        AddIncludeStrings("Recipes.UserFavoriteRecipes");
    }
}

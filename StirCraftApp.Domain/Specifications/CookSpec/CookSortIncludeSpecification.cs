using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.CookSpec;
public class CookSortIncludeSpecification : BaseSpecification<Cook>
{
    public CookSortIncludeSpecification(CookSpecParams specParams)
        : base(c => c.AppUser.DisplayName != null && (string.IsNullOrEmpty(specParams.CookName)
                                                      || c.AppUser.DisplayName.Contains(specParams.CookName.ToLower())))
    {
        AddInclude(c => c.AppUser);
        AddInclude(c => c.CookingRank);
        AddInclude(c => c.Recipes);

        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "recipeCountAsc":
                AddOrderBy(c => c.Recipes.Any() ? c.Recipes.Count : 0);
                break;
            case "recipeCountDesc":
                AddOrderByDesc(c => c.Recipes.Any() ? c.Recipes.Count : 0);
                break;
            case "rankAsc":
                AddOrderBy(c => c.RankingPoints);
                break;
            default: //Rank desc is default state of ordering 
                AddOrderByDesc(c => c.RankingPoints);
                break;
        }
    }
}

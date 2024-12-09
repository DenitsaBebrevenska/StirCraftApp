using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeFilterSortIncludeSpecification : BaseSpecification<Recipe>
{
    public RecipeFilterSortIncludeSpecification(RecipeSpecParams specParams)
    : base(r =>
        r.IsAdminApproved == true &&
        (!specParams.IngredientId.HasValue || r.RecipeIngredients.Any(ri => ri.IngredientId == specParams.IngredientId)) &&
        (string.IsNullOrEmpty(specParams.RecipeName) || r.Name.ToLower().Contains(specParams.RecipeName.ToLower())) &&
        (!specParams.Categories.Any() || r.CategoryRecipes.Any(cr => specParams.Categories.Contains(cr.Category.Name.ToLower()))) &&
       (!specParams.DifficultyLevels.Any() || specParams.DifficultyLevels.Contains(r.DifficultyLevel))
        )
    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddInclude(r => r.Cook);
        AddInclude(r => r.CategoryRecipes);
        AddIncludeStrings("CategoryRecipes.Category");
        AddIncludeStrings("RecipeIngredients.Ingredient");


        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "difficultyLevelAsc":
                AddOrderBy(r => r.DifficultyLevel);
                break;
            case "difficultyLevelDesc":
                AddOrderByDesc(r => r.DifficultyLevel);
                break;
            case "ratingAsc":
                AddOrderBy(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
                break;
            default: //Rating desc is default state of ordering 
                AddOrderByDesc(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
                break;
        }
    }
}

using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeFilterSortIncludeSpecification : BaseSpecification<Recipe>
{
    //a recipe could be filtered by name, difficulty level, categories
    //sort by difficulty lvl, by average rating
    public RecipeFilterSortIncludeSpecification(RecipeSpecParams specParams)
    : base(r =>
        (string.IsNullOrWhiteSpace(specParams.RecipeName) || r.Name.ToLower().Contains(specParams.RecipeName)) &&
        (!specParams.Categories.Any() || r.CategoryRecipes.Any(cr => specParams.Categories.Contains(cr.Category.Name.ToLower()))) &&
       (!specParams.DifficultyLevels.Any() || specParams.DifficultyLevels.Contains(r.DifficultyLevel))
        )
    {
        //todo have to decide whether to use single or split queries and in which cases
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddInclude(r => r.Cook);
        AddInclude(r => r.CategoryRecipes);
        AddIncludeStrings("CategoryRecipes.Category");


        //todo check if pagination is well implemented after more recipes are accumulated
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

using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeSpecification : BaseSpecification<Recipe>
{
    //a recipe could be filtered by name, category/categories, difficulty level,
    //sort by likes or default
    public RecipeSpecification(RecipeSpecParams specParams)
    : base(r =>
        (string.IsNullOrWhiteSpace(specParams.RecipeName) || r.Name.ToLower().Contains(specParams.RecipeName)) &&
        !specParams.Categories.Any() || specParams.Categories.Contains(r.Name) &&
        !specParams.DifficultyLevels.Any() || specParams.DifficultyLevels.Contains(r.DifficultyLevel.ToString().ToLower()))
    {
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "likesDesc":
                AddOrderByDesc(r => r.Name);
                break;
            default:
                AddOrderBy(r => r.Name);
                break;
        }
    }
}

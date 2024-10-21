using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeSpecification : BaseSpecification<Recipe>
{
    //a recipe could be filtered by name, category/categories, difficulty level, maybe cook name?, sort by likes
    public RecipeSpecification(string? name, string? difficultyLevel, string? sort)
    : base(r =>
        (string.IsNullOrWhiteSpace(name) || r.Name == name) &&
        (string.IsNullOrWhiteSpace(difficultyLevel) || string.Equals(r.DifficultyLevel.ToString().ToLower(),
            difficultyLevel.ToLower(), StringComparison.InvariantCulture)))
    {
        switch (sort)
        {
            case "likesAsc":
                AddOrderBy(r => r.Likes);
                break;
            case "likesDesc":
                AddOrderByDesc(r => r.Likes);
                break;
            default:
                AddOrderBy(r => r.Name);
                break;
        }
    }
}

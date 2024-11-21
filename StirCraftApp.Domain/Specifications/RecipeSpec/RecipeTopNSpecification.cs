using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeTopNSpecification : BaseSpecification<Recipe>
{
    public RecipeTopNSpecification(int count)
    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddInclude(r => r.Cook);
        AddOrderByDesc(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
        AddPaging(0, count);
    }
}

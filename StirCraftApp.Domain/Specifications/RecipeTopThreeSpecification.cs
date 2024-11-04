using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeTopThreeSpecification : BaseSpecification<Recipe>
{
    public RecipeTopThreeSpecification()
    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddInclude(r => r.Cook);
        AddOrderByDesc(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
        AddPaging(0, 3);
    }
}

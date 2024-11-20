using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class AllergenIngredientSpecification : BaseSpecification<Ingredient>
{
    public AllergenIngredientSpecification(IngredientSpecParams specParams) : base(i => i.IsAllergen)
    {
        AddOrderBy(c => c.Name);
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }
}

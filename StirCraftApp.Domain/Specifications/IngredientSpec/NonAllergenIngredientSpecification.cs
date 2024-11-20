using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class NonAllergenIngredientSpecification : BaseSpecification<Ingredient>
{
    public NonAllergenIngredientSpecification(IngredientSpecParams specParams) : base(i => i.IsAllergen == false)
    {
        AddOrderBy(i => i.Name);
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }
}

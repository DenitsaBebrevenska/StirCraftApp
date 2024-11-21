using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class IngredientFilterSpecification : BaseSpecification<Ingredient>
{
    public IngredientFilterSpecification(IngredientSpecParams specParams)
        : base(i =>
            (string.IsNullOrEmpty(specParams.IngredientName) ||
             i.Name.ToLower().Contains(specParams.IngredientName)) &&
            (!specParams.IsAllergen.HasValue ||
             i.IsAllergen == specParams.IsAllergen.Value))
    {
        AddOrderBy(c => c.Name);
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

}

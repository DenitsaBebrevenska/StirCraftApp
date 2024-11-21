using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class IngredientFilterSpecification : BaseSpecification<Ingredient>
{
    public IngredientFilterSpecification(IngredientSpecParams specParams)
        : base(c =>
            (string.IsNullOrEmpty(specParams.IngredientName) || c.Name.ToLower().Contains(specParams.IngredientName))
        )
    {
        AddOrderBy(c => c.Name);
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }

}

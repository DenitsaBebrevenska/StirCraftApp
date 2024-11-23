using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class IngredientFilterAdminPanelSpecification : BaseSpecification<Ingredient>
{
    public IngredientFilterAdminPanelSpecification(IngredientAdminPanelSpecParams specParams)
        : base(i => (string.IsNullOrEmpty(specParams.IngredientName) || i.Name.ToLower().Contains(specParams.IngredientName)) &&
                    (!specParams.IsAdminApproved.HasValue ||
                     i.IsAdminApproved == specParams.IsAdminApproved.Value))
    {
        AddOrderBy(c => c.Name);
        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }
}

using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.IngredientSpec;
public class IngredientAdminApprovedSpecification : BaseSpecification<Ingredient>
{
    public IngredientAdminApprovedSpecification() : base(i => i.IsAdminApproved == true)
    {

    }
}

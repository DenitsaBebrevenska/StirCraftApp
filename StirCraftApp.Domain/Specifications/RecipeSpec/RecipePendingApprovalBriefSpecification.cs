using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipePendingApprovalBriefSpecification : BaseSpecification<Recipe>
{
    public RecipePendingApprovalBriefSpecification(PagingParams pagingParams) : base(r => r.IsAdminApproved == false)
    {
        AddInclude(r => r.Cook);
        AddInclude(r => r.RecipeImages);
        AddOrderBy(r => r.CreatedOn);

        AddPaging(pagingParams.PageSize * (pagingParams.PageIndex - 1), pagingParams.PageSize);
    }
}

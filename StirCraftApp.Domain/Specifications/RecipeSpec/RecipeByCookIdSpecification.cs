﻿using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.RecipeSpec;
public class RecipeByCookIdSpecification : BaseSpecification<Recipe>
{
    public RecipeByCookIdSpecification(PagingParams pagingParams, int id) : base(r => r.CookId == id && r.IsAdminApproved == true)

    {
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.CategoryRecipes);
        AddInclude(r => r.RecipeRatings);
        AddIncludeStrings("CategoryRecipes.Category");
        AddOrderBy(r => r.CreatedOn);
        AddPaging(pagingParams.PageSize * (pagingParams.PageIndex - 1), pagingParams.PageSize);
    }
}

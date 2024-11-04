﻿using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications;
public class RecipeFilterSortIncludeSpecification : BaseSpecification<Recipe>
{
    //a recipe could be filtered by name, difficulty level, categories
    //sort by difficulty lvl, by average rating
    public RecipeFilterSortIncludeSpecification(RecipeSpecParams? specParams)
    : base(r =>
        (string.IsNullOrWhiteSpace(specParams.RecipeName) || r.Name.ToLower().Contains(specParams.RecipeName)) &&
        (!specParams.Categories.Any() || specParams.Categories.Contains(r.Name)) &&
        (!specParams.DifficultyLevels.Any() || specParams.DifficultyLevels.Contains(r.DifficultyLevel.ToString().ToLower()))
        )
    {
        //todo Compiling a query which loads related collections for more than one collection navigation, either via 'Include' or through projection, but no 'QuerySplittingBehavior' has been configured. By default, Entity Framework will use 'QuerySplittingBehavior.SingleQuery', which can potentially result in slow query performance. See https://go.microsoft.com/fwlink/?linkid=2134277 for more information. To identify the query that's triggering this warning call 'ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))'.
        //have to decide whether to use single or split queries and in which cases
        AddInclude(r => r.RecipeImages);
        AddInclude(r => r.RecipeRatings);
        AddInclude(r => r.Cook);

        AddPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        //todo the ordering is not working out
        switch (specParams.Sort)
        {
            case "difficultyLevelAsc":
                AddOrderBy(r => r.DifficultyLevel);
                break;
            case "difficultyLevelDesc":
                AddOrderByDesc(r => r.DifficultyLevel);
                break;
            case "ratingAsc":
                AddOrderBy(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
                break;
            default: //Rating desc is default state of ordering and for some reason that gets the other way around into asc order
                AddOrderByDesc(r => r.RecipeRatings.Any() ? r.RecipeRatings.Average(rr => rr.Value) : 0);
                break;
        }
    }
}

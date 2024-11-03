using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;

public class RecipeService(IUnitOfWork unit, UserManager<AppUser> userManager) : IRecipeService
{
    //todo handle exceptions better
    public async Task<DetailedRecipeDto> GetRecipeByIdAsync(int id)
    {
        var recipeIsFound = await unit.Repository<Recipe>()
            .Exists(id);

        if (!recipeIsFound)
        {
            throw new Exception("Recipe not found");
        }

        var spec = new RecipeIncludeAllSpecification();
        var recipe = await unit.Repository<Recipe>()
            .GetEntityWithSpecAsync(spec, id);

        var model = new DetailedRecipeDto()
        {
            Id = recipe!.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName = userManager.Users.FirstOrDefault(u => u.Id == recipe.Cook.UserId)?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value) : 0,
            Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto
            {
                Id = ri.Ingredient.Id,
                Name = ri.Ingredient.Name,
                Quantity = ri.Quantity,
                MeasurementUnitName = ri.MeasurementUnit?.Abbreviation
            }).ToList(),
            Images = recipe.RecipeImages.Select(ri => new RecipeImageDto
            {
                Id = ri.Id,
                Url = ri.Url
            }).ToList(),
            Comments = recipe.Comments.Select(c => new RecipeCommentDto
            {
                Id = c.Id,
                Body = c.Body,
                Title = c.Title,
                UserId = c.UserId,
                UserDisplayName = userManager.Users.FirstOrDefault(u => u.Id == c.UserId)?.DisplayName ?? "",
                Replies = c.Replies
                    .Select(r => new CommentReplyDto()
                    {
                        Id = r.Id,
                        Body = r.Body,
                        UserId = r.UserId,
                        UserDisplayName = userManager.Users.FirstOrDefault(u => u.Id == r.UserId)?.DisplayName ?? ""
                    })
                    .ToList()
            })
            .ToList()

        };

        return model;
    }

    public async Task<PaginatedResult<SummaryRecipeDto>> GetRecipesAsync(RecipeFilterSortIncludeSpecification specParams)
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllWithSpecAsync(specParams); ;
        var filtered = recipes.Select(r => new SummaryRecipeDto
        {
            Id = r.Id,
            Name = r.Name,
            DifficultyLevel = r.DifficultyLevel.ToString(),
            MainImageUrl = r.RecipeImages.FirstOrDefault()?.Url, //todo should set default image for recipe without image
            CookName = userManager.Users.FirstOrDefault(u => u.Id == r.Cook.UserId)?.DisplayName ?? "",
            Rating = r.RecipeRatings.Average(rr => rr.Value).ToString("F2"),
            Likes = userManager
                .Users
                .Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == r.Id))
        })
            .ToList();

        var paginatedResult = new PaginatedResult<SummaryRecipeDto>(specParams.Skip,
            specParams.Take,
            filtered.Count(),
            filtered);


        return paginatedResult;
    }

    public async Task CreateRecipeAsync(FormRecipeDto createRecipeDto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRecipeAsync(FormRecipeDto updateRecipeDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRecipeAsync(int id)
    {
        throw new NotImplementedException();
    }
}


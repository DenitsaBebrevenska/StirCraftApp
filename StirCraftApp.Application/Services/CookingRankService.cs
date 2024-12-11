using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;
using static StirCraftApp.Domain.Constants.RankingConstants;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implements the ICookingRankService interface and uses the Unit of Work pattern for data access.
/// Provides functionality for calculating and updating the ranking points of cooks based on various actions, 
/// such as liking, unliking, uploading, and deleting recipes. It also handles recalculating the cook's rank 
/// based on their total ranking points and the required points for different ranks.
/// </summary>
public class CookingRankService(IUnitOfWork unit) : ICookingRankService
{

    /// <summary>
    /// Calculates the ranking points for a cook based on the specified action.
    /// Adjusts the cook's ranking points and updates their rank accordingly.
    /// </summary>
    /// <param name="cookId">The ID of the cook whose ranking points are to be updated.</param>
    /// <param name="action">The action that triggers the change in ranking points (e.g., LikingARecipe, UploadingARecipe).</param>
    public async Task CalculatePoints(int cookId, string action)
    {
        var cook = await unit.Repository<Cook>()
            .GetByIdAsync(null, cookId);

        if (cook == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Cook), cookId));
        }

        switch (action)
        {
            case LikingARecipe:
                cook.RankingPoints += RecipeLikeRankingPointsValue;
                break;
            case UnlikingARecipe:
                cook.RankingPoints -= RecipeLikeRankingPointsValue;
                break;
            case UploadingARecipe:
                cook.RankingPoints += RecipeUploadRankingPointsValue;
                break;
            case DeletingARecipe:
                cook.RankingPoints -= RecipeUploadRankingPointsValue;
                break;
            default:
                throw new ArgumentException("Invalid action");
        }


        if (cook.RankingPoints < 0)
        {
            cook.RankingPoints = 0;
        }

        await RecalculateRank(cook);

    }


    /// <summary>
    /// Recalculates the rank of a cook based on their total ranking points.
    /// Adjusts the cook's rank ID based on the available ranks and required points.
    /// </summary>
    /// <param name="cook">The cook whose rank is to be recalculated.</param>
    private async Task RecalculateRank(Cook cook)
    {
        var ranks = await unit.Repository<CookingRank>()
            .GetAllAsync(null);
        var currentRankPosition = ranks.IndexOf(ranks.First(r => r.Id == cook.CookingRankId));
        var previousRankPosition = currentRankPosition == 0 ? 0 : currentRankPosition - 1;
        var nextRankPosition = currentRankPosition == ranks.Count - 1 ? ranks.Count - 1 : currentRankPosition + 1;

        if (cook.RankingPoints < cook.CookingRank.RequiredPoints)
        {
            cook.CookingRankId = ranks[previousRankPosition].Id;
        }
        else if (cook.RankingPoints >= ranks[nextRankPosition].RequiredPoints)
        {
            cook.CookingRankId = ranks[nextRankPosition].Id;
        }

        await unit.CompleteAsync();
    }
}

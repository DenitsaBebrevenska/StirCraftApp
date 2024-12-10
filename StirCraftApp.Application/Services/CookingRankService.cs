using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;
using static StirCraftApp.Domain.Constants.RankingConstants;

namespace StirCraftApp.Application.Services;

public class CookingRankService(IUnitOfWork unit) : ICookingRankService
{
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

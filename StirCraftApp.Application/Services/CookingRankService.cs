using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.RankingConstants;

namespace StirCraftApp.Application.Services;

public class CookingRankService(IUnitOfWork unit) : ICookingRankService
{
    public async Task CalculatePoints(int cookId, string action)
    {
        var cook = await unit.Repository<Cook>()
            .GetByIdAsync(cookId);

        if (cook == null)
        {
            throw new Exception($"Cook with id {cookId} was not found.");
        }

        switch (action)
        {
            case "like":
                cook.RankingPoints += RecipeLikeRankingPointsValue;
                break;
            case "unlike":
                cook.RankingPoints -= RecipeLikeRankingPointsValue;
                break;
            case "upload":
                cook.RankingPoints += RecipeUploadRankingPointsValue;
                break;
            case "delete":
                cook.RankingPoints -= RecipeUploadRankingPointsValue;
                break;
            default:
                throw new ArgumentException("Invalid action");
        }

        await RecalculateRank(cook);

    }

    private async Task RecalculateRank(Cook cook)
    {
        var ranks = await unit.Repository<CookingRank>()
            .GetAllAsync();
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

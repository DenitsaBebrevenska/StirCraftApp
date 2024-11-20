namespace StirCraftApp.Application.Contracts;
public interface ICookingRankService
{
    Task CalculatePoints(int cookId, string action);
}

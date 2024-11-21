using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.CookSpec;
public class CookTopRankSpecification : BaseSpecification<Cook>
{
    public CookTopRankSpecification(int count)
    {
        AddInclude(c => c.CookingRank);
        AddOrderByDesc(c => c.RankingPoints);
        AddPaging(0, count);
    }
}

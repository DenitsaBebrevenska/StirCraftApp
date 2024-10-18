using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class CookingRankConfiguration : IEntityTypeConfiguration<CookingRank>
{
	public void Configure(EntityTypeBuilder<CookingRank> builder)
	{
		var ranks = JsonSeedHelper.LoadJsonData<CookingRank>("CookingRanks");

		builder.HasData(ranks);
	}
}

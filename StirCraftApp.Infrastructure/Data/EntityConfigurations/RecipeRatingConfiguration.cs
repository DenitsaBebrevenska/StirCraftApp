using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRating>
{
	public void Configure(EntityTypeBuilder<RecipeRating> builder)
	{
		var ratings = JsonSeedHelper.LoadJsonData<RecipeRating>("RecipeRatings");

		builder.HasData(ratings);
	}
}

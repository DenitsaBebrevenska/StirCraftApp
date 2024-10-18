using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class RecipeImageConfiguration : IEntityTypeConfiguration<RecipeImage>
{
	public void Configure(EntityTypeBuilder<RecipeImage> builder)
	{
		var images = JsonSeedHelper.LoadJsonData<RecipeImage>("RecipeImages");

		builder.HasData(images);
	}
}

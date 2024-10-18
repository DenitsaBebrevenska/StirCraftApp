using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
	public void Configure(EntityTypeBuilder<Recipe> builder)
	{
		var recipes = JsonSeedHelper.LoadJsonData<Recipe>("Recipes");

		builder.HasData(recipes);
	}
}

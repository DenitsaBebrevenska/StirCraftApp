using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
	public void Configure(EntityTypeBuilder<Ingredient> builder)
	{
		var ingredients = JsonSeedHelper.LoadJsonData<Ingredient>("Ingredients");

		builder.HasData(ingredients);
	}
}

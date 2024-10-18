using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
{
	public void Configure(EntityTypeBuilder<ShoppingList> builder)
	{
		var shoppingLists = JsonSeedHelper.LoadJsonData<ShoppingList>("ShoppingLists");

		builder.HasData(shoppingLists);
	}
}

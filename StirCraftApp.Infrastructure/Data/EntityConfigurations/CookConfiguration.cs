using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class CookConfiguration : IEntityTypeConfiguration<Cook>
{
	public void Configure(EntityTypeBuilder<Cook> builder)
	{
		var cooks = JsonSeedHelper.LoadJsonData<Cook>("Cooks");

		builder.HasData(cooks);
	}
}

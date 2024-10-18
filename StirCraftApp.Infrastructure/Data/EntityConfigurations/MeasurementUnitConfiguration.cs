using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
{
	public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
	{
		var units = JsonSeedHelper.LoadJsonData<MeasurementUnit>("MeasurementUnits");

		builder.HasData(units);
	}
}

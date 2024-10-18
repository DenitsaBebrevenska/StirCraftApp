using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		var roles = JsonSeedHelper.LoadJsonData<IdentityRole>("Roles");

		builder.HasData(roles);
	}

}

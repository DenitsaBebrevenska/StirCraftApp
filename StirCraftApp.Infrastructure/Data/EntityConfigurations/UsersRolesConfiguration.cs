using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;

public class UsersRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
	{
		var usersRoles = JsonSeedHelper.LoadJsonData<IdentityUserRole<string>>("UsersRoles");

		builder.HasData(usersRoles);
	}
}


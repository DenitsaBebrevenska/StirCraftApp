using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var users = JsonSeedHelper.LoadJsonData<AppUser>("Users");

        var hasher = new PasswordHasher<AppUser>();

        for (var index = 1; index <= users.Count; index++)
        {
            var user = users[index - 1];
            user.PasswordHash = hasher.HashPassword(user, $"Test@{index}");
        }

        builder.HasData(users);
    }
}

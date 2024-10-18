using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		var comments = JsonSeedHelper.LoadJsonData<Comment>("Comments");

		builder.HasData(comments);
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
{
	public void Configure(EntityTypeBuilder<Reply> builder)
	{
		var replies = JsonSeedHelper.LoadJsonData<Reply>("Replies");

		builder.HasData(replies);
	}
}

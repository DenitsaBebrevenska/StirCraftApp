using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StirCraftApp.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
	{
		var connectionString = config.GetConnectionString("DefaultConnection") ??
							   throw new ArgumentException("DefaultConnection string not set.");

		services.AddDbContext<StirCraftDbContext>(options => options.UseSqlServer(connectionString));

		return services;
	}
}

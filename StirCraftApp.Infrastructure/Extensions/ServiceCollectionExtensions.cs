using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Infrastructure.Data;
using StirCraftApp.Infrastructure.Data.Interceptors;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
	{
		var connectionString = config.GetConnectionString("DefaultConnection") ??
							   throw new ArgumentException("DefaultConnection string not set.");


		services.AddDbContext<StirCraftDbContext>(options => options.UseSqlServer(connectionString)
			.AddInterceptors(new SoftDeleteInterceptor()));

		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

		return services;
	}
}

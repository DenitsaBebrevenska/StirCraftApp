using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Infrastructure.Data;
using StirCraftApp.Infrastructure.Data.Interceptors;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICookService, CookService>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ??
                               throw new ArgumentException("DefaultConnection string not set.");


        services.AddDbContext<StirCraftDbContext>(options => options.UseSqlServer(connectionString)
            .AddInterceptors(new SoftDeleteInterceptor()));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}

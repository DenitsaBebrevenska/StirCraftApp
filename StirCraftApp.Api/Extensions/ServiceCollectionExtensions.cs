using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICooksService, CooksService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<ICookingRankService, CookingRankService>();
        services.AddScoped<ICookService, CookService>();
        services.AddScoped<IMeasurementUnitService, MeasurementUnitService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IReplyService, ReplyService>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ??
                               throw new ArgumentException("DefaultConnection string not set.");


        services.AddDbContext<StirCraftDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}

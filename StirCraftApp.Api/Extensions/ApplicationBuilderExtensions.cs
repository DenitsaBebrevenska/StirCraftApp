namespace StirCraftApp.Api.Extensions;

/// <summary>
/// Extension method for adding GlobalExceptionMiddleware to the application pipeline.
/// </summary>
public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}

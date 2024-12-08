using StirCraftApp.Application.Exceptions;

namespace StirCraftApp.Api.Extensions;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogWarning(ex, "Not Found Exception occurred");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new
            {
                ex.Message,
                StatusCode = StatusCodes.Status404NotFound
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.LogWarning(ex, "Unauthorized Access Exception occurred");
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new
            {
                ex.Message,
                StatusCode = StatusCodes.Status403Forbidden
            });
        }
        catch (ValidationException ex)
        {
            logger.LogWarning(ex, "Validation Exception occurred");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                ex.Message,
                StatusCode = StatusCodes.Status400BadRequest
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception has occurred");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = "An unexpected error occurred",
                StatusCode = StatusCodes.Status500InternalServerError
            });
        }
    }
}

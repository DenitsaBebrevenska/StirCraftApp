using Microsoft.AspNetCore.Mvc.Filters;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class InvalidateCacheAttribute(params string[] pattern) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();

        if (resultContext.Exception == null || resultContext.ExceptionHandled)
        {
            var cacheService = context.HttpContext.RequestServices
                .GetRequiredService<IResponseCacheService>();

            foreach (var patternString in pattern)
            {
                cacheService.RemoveCacheKeysByPattern(patternString);
            }
        }
    }
}

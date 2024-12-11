using Microsoft.AspNetCore.Mvc.Filters;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Attributes;

/// <summary>
/// An attribute that invalidates cache entries based on specified patterns after an action is executed.
/// </summary>
/// <remarks>
/// This attribute is used to remove cached responses from the cache service using a list of patterns.
/// It is executed asynchronously and ensures cache invalidation only if the action completes successfully
/// </remarks>
/// <param name="pattern">
/// An array of string patterns that are used to match and remove cache keys.
/// </param>
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

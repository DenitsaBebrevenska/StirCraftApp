using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StirCraftApp.Application.Contracts;
using System.Text;

namespace StirCraftApp.Api.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class CacheAttribute(int slidingTimeSeconds, int absoluteTimeSeconds) : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

        var cacheKey = GenerateCacheKey(context.HttpContext.Request);

        var cachedResponse = cacheService.GetCachedResponse(cacheKey);

        if (!string.IsNullOrEmpty(cachedResponse))
        {
            var contentResult = new ContentResult
            {
                Content = cachedResponse,
                ContentType = "application/json",
                StatusCode = 200
            };

            context.Result = contentResult;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is OkObjectResult okObjectResult)
        {
            if (okObjectResult.Value != null)
            {
                var cacheKey = GenerateCacheKey(context.HttpContext.Request);
                var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

                cacheService.CacheResponse(
                    cacheKey,
                    okObjectResult.Value,
                    TimeSpan.FromSeconds(slidingTimeSeconds),
                    TimeSpan.FromSeconds(absoluteTimeSeconds)
                );
            }

        }
    }

    private static string GenerateCacheKey(HttpRequest request)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append($"{request.Path}");

        foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
        {
            keyBuilder.Append($"|{key}-{value}");
        }

        return keyBuilder.ToString().TrimEnd();
    }


}


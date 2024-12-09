using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using StirCraftApp.Application.Contracts;
using System.Text.Json;

namespace StirCraftApp.Application.Services;
public class ResponseCacheService(IMemoryCache memoryCache, ILogger<ResponseCacheService> logger) : IResponseCacheService
{
    private IDictionary<string, string> _cacheKeys = new Dictionary<string, string>();
    public void CacheResponse(string cacheKey, object response, TimeSpan timeToLiveSliding, TimeSpan timeToLiveAbsolute)
    {
        var serializedResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        memoryCache.Set(cacheKey, serializedResponse, new MemoryCacheEntryOptions
        {
            SlidingExpiration = timeToLiveSliding,
            AbsoluteExpirationRelativeToNow = timeToLiveAbsolute
        });

        _cacheKeys.TryAdd(cacheKey, cacheKey);

        logger.LogInformation($"Response is cached - key {cacheKey}.");
    }

    public string? GetCachedResponse(string cacheKey)
    {
        memoryCache.TryGetValue(cacheKey, out string? cachedResponse);

        logger.LogInformation(string.IsNullOrEmpty(cachedResponse)
            ? "Response not found in cache."
            : "Response found in cache.");

        return cachedResponse;
    }

    public void RemoveCacheKeysByPattern(string cacheKeyPattern)
    {
        var keysToRemove = _cacheKeys.Keys
            .Where(k => k.Contains(cacheKeyPattern))
            .ToList();

        foreach (var key in keysToRemove)
        {
            memoryCache.Remove(key);
            _cacheKeys.Remove(key);
            logger.LogInformation($"Removing from cache - key {key}");
        }

    }
}

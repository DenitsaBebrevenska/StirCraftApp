using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using StirCraftApp.Application.Contracts;
using System.Text.Json;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implementation of IResponseCacheService. Uses IMemoryCache to cache responses in-memory and a logger to log information about the cache operations.
/// A service for managing in-memory caching of HTTP responses.
/// Provides methods for caching responses, retrieving cached responses, and removing cache entries based on patterns.
/// </summary>
public class ResponseCacheService(IMemoryCache memoryCache, ILogger<ResponseCacheService> logger) : IResponseCacheService
{
    private IDictionary<string, string> _cacheKeys = new Dictionary<string, string>();

    /// <summary>
    /// Caches a response in memory with sliding and absolute expiration times.
    /// </summary>
    /// <param name="cacheKey">The unique key used to store the response in the cache.</param>
    /// <param name="response">The response object to be cached.</param>
    /// <param name="timeToLiveSliding">The sliding expiration time for the cached response.</param>
    /// <param name="timeToLiveAbsolute">The absolute expiration time for the cached response.</param>
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

    /// <summary>
    /// Retrieves a cached response by its cache key.
    /// </summary>
    /// <param name="cacheKey">The key associated with the cached response.</param>
    /// <returns>The cached response as a string, or null if not found.</returns>
    public string? GetCachedResponse(string cacheKey)
    {
        memoryCache.TryGetValue(cacheKey, out string? cachedResponse);

        logger.LogInformation(string.IsNullOrEmpty(cachedResponse)
            ? "Response not found in cache."
            : "Response found in cache.");

        return cachedResponse;
    }

    /// <summary>
    /// Removes cached entries matching a specific key pattern.
    /// </summary>
    /// <param name="cacheKeyPattern">The pattern to match cache keys for removal.</param>
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

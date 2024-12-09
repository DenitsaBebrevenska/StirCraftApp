namespace StirCraftApp.Application.Contracts;
public interface IResponseCacheService
{
    void CacheResponse(string cacheKey, object response, TimeSpan timeToLiveSliding, TimeSpan timeToLiveAbsolute);

    string? GetCachedResponse(string cacheKey);

    void RemoveCache(string cacheKey);
}

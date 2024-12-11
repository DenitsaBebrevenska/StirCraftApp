using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using StirCraftApp.Application.Services;
using System.Text.Json;
using Xunit;

namespace StirCraftApp.Tests;
public class ResponseCacheUnitServiceTests
{
    private readonly Mock<IMemoryCache> _memoryCacheMock;
    private readonly Mock<ILogger<ResponseCacheService>> _loggerMock;
    private readonly ResponseCacheService _service;
    public ResponseCacheUnitServiceTests()
    {
        _memoryCacheMock = new Mock<IMemoryCache>();
        _loggerMock = new Mock<ILogger<ResponseCacheService>>();
        _service = new ResponseCacheService(_memoryCacheMock.Object, _loggerMock.Object);
    }

    [Fact]
    public void GetCachedResponse_WhenResponseExists_ReturnsCachedResponse()
    {
        string cacheKey = "existing-key";
        var expectedResponse = JsonSerializer.Serialize(new { Name = "Cached Object" });
        object? cachedValue = expectedResponse;

        _memoryCacheMock
            .Setup(x => x.TryGetValue(cacheKey, out cachedValue))
            .Returns(true);

        var result = _service.GetCachedResponse(cacheKey);

        Assert.Equal(expectedResponse, result);

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Response found in cache")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once);
    }

    [Fact]
    public void GetCachedResponse_WhenResponseNotExists_ReturnsNull()
    {
        string cacheKey = "non-existing-key";
        object? cachedValue = null;

        _memoryCacheMock
           .Setup(x => x.TryGetValue(cacheKey, out cachedValue))
           .Returns(false);

        var result = _service.GetCachedResponse(cacheKey);

        Assert.Null(result);

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Response not found in cache")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once);
    }

    [Fact]
    public void RemoveCacheKeysByPattern_RemovesMatchingKeys()
    {
        string pattern = "user-";
        var cacheKeys = new[]
        {
            "user-1",
            "user-2",
            "product-1"
        };


        var responseCacheService = new ResponseCacheService(
            _memoryCacheMock.Object,
            _loggerMock.Object);


        var cacheKeysField = typeof(ResponseCacheService)
            .GetField("_cacheKeys", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var dictionary = (IDictionary<string, string>)cacheKeysField.GetValue(responseCacheService);
        foreach (var key in cacheKeys)
        {
            dictionary[key] = key;
        }

        responseCacheService.RemoveCacheKeysByPattern("user-");

        _memoryCacheMock.Verify(x => x.Remove("user-1"), Times.Once);
        _memoryCacheMock.Verify(x => x.Remove("user-2"), Times.Once);
        _memoryCacheMock.Verify(x => x.Remove("product-1"), Times.Never);

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Removing from cache - key user-1")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once);

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Removing from cache - key user-2")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once);
    }

}



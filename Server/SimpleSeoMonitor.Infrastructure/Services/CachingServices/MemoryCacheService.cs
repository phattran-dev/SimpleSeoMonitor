using Microsoft.Extensions.Caching.Memory;
using SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Services.CachingServices
{
    public class MemoryCacheService(IMemoryCache _cache) : ICacheService
    {
        public async Task<T> SetCacheAsync<T>(string key, T value, TimeSpan expiration, CancellationToken cancellationToken = default)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            _cache.Set(key, value, cacheEntryOptions);
            return value;
        }

        public async Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            return _cache.TryGetValue(key, out T? value) ? value : default;
        }

        public async Task<bool> RemoveCacheAsync(string key, CancellationToken cancellationToken = default)
        {
            _cache.Remove(key);
            return true;
        }
    }
}

using SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Services.CachingServices
{
    public class MemoryCacheService : IMemoryCacheService
    {
        public Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCacheAsync(string key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> SetCacheAsync<T>(string key, T value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

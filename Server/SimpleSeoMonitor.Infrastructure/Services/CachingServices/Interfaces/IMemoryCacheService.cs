namespace SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces
{
    public interface IMemoryCacheService
    {
        Task<T> SetCacheAsync<T>(string key, T value, CancellationToken cancellationToken = default);
        Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default);
        Task<bool> RemoveCacheAsync(string key, CancellationToken cancellationToken = default);
    }
}

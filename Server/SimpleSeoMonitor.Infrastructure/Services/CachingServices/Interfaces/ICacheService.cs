namespace SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces
{
    public interface ICacheService
    {
        Task<T> SetCacheAsync<T>(string key, T value, TimeSpan expiration, CancellationToken cancellationToken = default);
        Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default);
        Task<bool> RemoveCacheAsync(string key, CancellationToken cancellationToken = default);
    }
}

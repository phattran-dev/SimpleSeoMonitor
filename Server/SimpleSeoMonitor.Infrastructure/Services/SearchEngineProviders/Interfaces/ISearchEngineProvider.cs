namespace SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces
{
    public interface ISearchEngineProvider
    {
        Task<List<int>?> GetSEOIndexesAsync(string url, string keyword, CancellationToken cancellationToken = default);
    }
}

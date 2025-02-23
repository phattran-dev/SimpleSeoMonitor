namespace SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces
{
    public interface ISearchEngineProvider
    {
        Task<List<int>?> GetSEOIndexesAsync(string? targetWebsite, string? keyword, int limitSearchResults, CancellationToken cancellationToken = default);
    }
}

using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders
{
    public class BingSearchEngineProvider(IHttpClientFactory _httpClientFactory) : ISearchEngineProvider
    {
        public Task<List<int>?> GetSEOIndexesAsync(string url, string keyword, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

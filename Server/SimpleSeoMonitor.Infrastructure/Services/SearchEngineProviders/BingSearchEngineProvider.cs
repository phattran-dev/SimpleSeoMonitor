using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders
{
    public class BingSearchEngineProvider(HttpClient httpClient) : ISearchEngineProvider
    {
        private readonly HttpClient _httpClient = httpClient;
        public Task<List<int>?> GetSEOIndexesAsync(string url, string keyword, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

using SimpleSeoMonitor.Domain.Shared.Helpers;
using SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders
{
    public class BingSearchEngineProvider(IHttpClientFactory _httpClientFactory,
        IHttpHelper _httpHelpers,
        IRegexHelper _regexHelper) : ISearchEngineProvider
    {
        /// <summary>
        /// q: keyword;
        /// start: page number;
        /// num: total item per page;
        /// </summary>
        private readonly string searchQuery = "search?q={0}&first={1}&num={2}";
        private readonly int totalItemPerPage = 1;

        public async Task<List<int>?> GetSEOIndexesAsync(string? targetWebsite, string? keyword, int limitSearchResults, CancellationToken cancellationToken = default)
        {
            #region Validate Inputs
            if (string.IsNullOrWhiteSpace(targetWebsite))
                throw new ArgumentNullException("Url is empty!");

            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentNullException("Keyword is empty!");

            if (limitSearchResults <= 0)
                return null;

            var baseTargetWebsite = string.Empty;
            if (!_regexHelper.IsValidUrl(targetWebsite, out baseTargetWebsite))
                throw new Exception("Url is invalid!");
            #endregion Validate Inputs

            var results = new List<int>();

            var httpClient = _httpClientFactory.CreateClient("BingSearchEngine");

            var tasks = new Dictionary<int, Task<string?>>();
            for (int pageNumber = 1; pageNumber <= limitSearchResults; pageNumber++)
            {
                var requestUri = string.Format(searchQuery, Uri.EscapeDataString(keyword), pageNumber, totalItemPerPage);
                tasks[pageNumber] = _httpHelpers.FetchHtmlContentAsync(httpClient, requestUri, cancellationToken);
            }

            await Task.WhenAll(tasks.Values);
            var pageResults = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var (pageNumber, htmlContent) in pageResults)
            {
                if (string.IsNullOrWhiteSpace(htmlContent))
                    continue;

                if (_httpHelpers.IsHtmlContentContainTargetWebsite(targetWebsite, htmlContent)
                    || _httpHelpers.IsHtmlContentContainTargetWebsite(baseTargetWebsite, htmlContent))
                    results.Add(pageNumber);
            }

            return results;
        }
    }
}

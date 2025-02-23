using Microsoft.Extensions.DependencyInjection;
using SimpleSeoMonitor.Domain.Shared.Enums;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Factories.SearchEngineProvider
{
    public class SearchEngineProviderFactory(IEnumerable<ISearchEngineProvider> _searchEngineProviders) : ISearchEngineProviderFactory
    {
        public ISearchEngineProvider CreateSearchEngineProvider(SearchEngineType searchEngineType)
        {
            return searchEngineType switch
            {
                SearchEngineType.Google => _searchEngineProviders.OfType<GoogleSearchEngineProvider>().FirstOrDefault()
                    ?? throw new InvalidOperationException("Google search engine provider not found."),

                SearchEngineType.Bing => _searchEngineProviders.OfType<BingSearchEngineProvider>().FirstOrDefault()
                    ?? throw new InvalidOperationException("Bing search engine provider not found."),

                _ => throw new ArgumentException("Search engine not supported!")
            };
        }
    }
}

using SimpleSeoMonitor.Domain.Shared.Enums;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Factories.SearchEngineProvider
{
    public class SearchEngineProviderFactory : ISearchEngineProviderFactory
    {
        public ISearchEngineProvider CreateSearchEngineProvider(SearchEngineType searchEngineType)
        {
            throw new NotImplementedException();
        }
    }
}

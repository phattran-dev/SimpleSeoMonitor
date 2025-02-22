using SimpleSeoMonitor.Domain.Shared.Enums;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;

namespace SimpleSeoMonitor.Infrastructure.Factories.SearchEngineProvider
{
    public interface ISearchEngineProviderFactory
    {
        ISearchEngineProvider CreateSearchEngineProvider(SearchEngineType searchEngineType);
    }
}

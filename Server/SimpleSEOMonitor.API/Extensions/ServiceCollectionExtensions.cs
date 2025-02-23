using SimpleSeoMonitor.Domain.Core;
using SimpleSeoMonitor.Domain.Interfaces;
using SimpleSeoMonitor.Domain.Models;
using SimpleSeoMonitor.Domain.Shared.Constants;
using SimpleSeoMonitor.Domain.Shared.Helpers;
using SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces;
using SimpleSeoMonitor.Infrastructure.Factories.SearchEngineProvider;
using SimpleSeoMonitor.Infrastructure.Services.CachingServices;
using SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders;
using SimpleSeoMonitor.Infrastructure.Services.SearchEngineProviders.Interfaces;
using SimpleSEOMonitor.Application.Queries.GetSEOIndexes;

namespace SimpleSEOMonitor.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegistryQueryExecutor(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IQueryExecutor, QueryExecutor>();
            return service;
        }

        public static IServiceCollection AddServicesAndHelpers(this IServiceCollection services)
        {
            #region Helpers
            services.AddSingleton<IHttpHelper, HttpHelper>();
            services.AddSingleton<IRegexHelper, RegexHelper>();
            #endregion Helpers

            #region Services
            // Thirds
            services.AddMemoryCache();

            // Ours
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<ISearchEngineProviderFactory, SearchEngineProviderFactory>();
            services.AddTransient<ISearchEngineProvider, GoogleSearchEngineProvider>();
            services.AddTransient<ISearchEngineProvider, BingSearchEngineProvider>();
            #endregion Services

            return services;
        }

        public static IServiceCollection RegistryQueryHandlers(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetSEOIndexesQuery, BaseResponse<List<int>>>, GetSEOIndexesQueryHandler>();

            return services;
        }

        public static IServiceCollection RegistryHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient(SearchEngineConstants.GoogleHttpClientName, client =>
            {
                client.BaseAddress = new Uri(SearchEngineConstants.GoogleUri);
                client.DefaultRequestHeaders
                        .Add(SearchEngineConstants.HttpHeaderUserAgentName,
                            SearchEngineConstants.HttpHeaderUserAgentValue);
            });

            services.AddHttpClient(SearchEngineConstants.BingHttpClientName, client =>
            {
                client.BaseAddress = new Uri(SearchEngineConstants.BingUri);
                client.DefaultRequestHeaders
                        .Add(SearchEngineConstants.HttpHeaderUserAgentName,
                            SearchEngineConstants.HttpHeaderUserAgentValue);
            });

            return services;
        }
    }
}

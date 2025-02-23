using SimpleSeoMonitor.Domain.Interfaces;
using SimpleSeoMonitor.Domain.Models;
using SimpleSeoMonitor.Domain.Shared.Enums;
using SimpleSeoMonitor.Infrastructure.Factories.SearchEngineProvider;
using SimpleSeoMonitor.Infrastructure.Services.CachingServices.Interfaces;

namespace SimpleSEOMonitor.Application.Queries.GetSEOIndexes
{
    public sealed class GetSEOIndexesQueryHandler(ISearchEngineProviderFactory _searchEngineProviderFactory, ICacheService _cacheService) : IQueryHandler<GetSEOIndexesQuery, BaseResponse<List<int>>>
    {
        private readonly int limitResultSearch = 100;
        public async Task<BaseResponse<List<int>>> HandleAsync(GetSEOIndexesQuery query, CancellationToken cancellationToken = default)
        {
            try
            {
                var cacheKey = BuildCacheKey(query.TargetWebsite, query.Keyword, query.SearchEngineType);
                var cacheData = await _cacheService.GetCacheAsync<List<int>>(cacheKey, cancellationToken);
                if (cacheData != null)
                    return BaseResponse<List<int>>.Success(cacheData);

                var result = new List<int>();
                var searchEngineProvider = _searchEngineProviderFactory.CreateSearchEngineProvider(query.SearchEngineType);
                result = await searchEngineProvider.GetSEOIndexesAsync(query.TargetWebsite, query.Keyword, limitResultSearch, cancellationToken);
                await _cacheService.SetCacheAsync(cacheKey, result, TimeSpan.FromHours(1));

                return BaseResponse<List<int>>.Success(result);
            }
            catch (Exception ex)
            {
                return BaseResponse<List<int>>.Fail(ex.Message);
            }
        }

        private string BuildCacheKey(string? targetWebsite, string? keyword, SearchEngineType searchEngineType)
        {
            var uriKeyword = string.IsNullOrWhiteSpace(keyword) ? string.Empty : Uri.EscapeDataString(keyword);
            return $"Cache_{searchEngineType}_{targetWebsite}_{uriKeyword}";
        } 
    }
}

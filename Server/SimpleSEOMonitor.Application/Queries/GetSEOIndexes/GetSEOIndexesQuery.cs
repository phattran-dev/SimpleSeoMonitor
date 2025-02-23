using SimpleSeoMonitor.Domain.Interfaces;
using SimpleSeoMonitor.Domain.Models;
using SimpleSeoMonitor.Domain.Shared.Enums;

namespace SimpleSEOMonitor.Application.Queries.GetSEOIndexes
{
    public sealed class GetSEOIndexesQuery : IQuery<BaseResponse<List<int>>>
    {
        public string? Keyword { get; set; }
        public string? TargetWebsite { get; set; }
        public SearchEngineType SearchEngineType { get; set; }
    }
}

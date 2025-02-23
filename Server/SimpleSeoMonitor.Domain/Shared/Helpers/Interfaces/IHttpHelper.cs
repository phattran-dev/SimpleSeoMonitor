namespace SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces
{
    public interface IHttpHelper
    {
        Task<string?> FetchHtmlContentAsync(HttpClient _httpClient, string requestUri, CancellationToken cancellationToken = default);
        bool IsHtmlContentContainTargetWebsite(string targetWebsite, string htmlContent);

    }
}

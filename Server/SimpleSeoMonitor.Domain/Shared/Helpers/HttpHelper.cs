using System.Text.RegularExpressions;

namespace SimpleSeoMonitor.Domain.Shared.Helpers
{
    public class HttpHelper
    {
        public async Task<string?> FetchHtmlContentAsync(HttpClient _httpClient, string requestUri, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(requestUri, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsHtmlContentContainTargetWebsite(string targetWebsite, string htmlContent)
        {
            if (string.IsNullOrWhiteSpace(targetWebsite) || string.IsNullOrWhiteSpace(htmlContent))
                return false;

            string patternTargetWebsite = $@"<cite[^>]*>\s*https?:\/\/{Regex.Escape(targetWebsite)}";

            return Regex.IsMatch(htmlContent, patternTargetWebsite, RegexOptions.IgnoreCase);
        }
    }
}

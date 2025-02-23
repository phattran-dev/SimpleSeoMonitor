namespace SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces
{
    public interface IRegexHelper
    {
        bool IsValidUrl(string url, out string baseUrl);
    }
}

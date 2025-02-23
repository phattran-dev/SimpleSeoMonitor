using System.Text.RegularExpressions;

namespace SimpleSeoMonitor.Domain.Shared.Helpers
{
    public static class RegexHelper
    {
        public static bool IsValidUrl(string url, out string baseUrl)
        {
            string pattern = @"^(https?|ftp):\/\/([^\/]+)";
            Match match = Regex.Match(url, pattern, RegexOptions.IgnoreCase);

            if(match.Success)
            {
                baseUrl = match.Value;
                return true;
            }

            baseUrl = string.Empty;
            return false;
        }
    }
}

using SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces;
using System.Text.RegularExpressions;

namespace SimpleSeoMonitor.Domain.Shared.Helpers
{
    public sealed class RegexHelper : IRegexHelper
    {
        public bool IsValidUrl(string url, out string baseUrl)
        {
            string pattern = @"^(https?|ftp):\/\/([^\/]+)";
            Match match = Regex.Match(url, pattern, RegexOptions.IgnoreCase);

            if(match.Success)
            {
                baseUrl = match.Groups[2].Value;
                return true;
            }

            baseUrl = string.Empty;
            return false;
        }
    }
}

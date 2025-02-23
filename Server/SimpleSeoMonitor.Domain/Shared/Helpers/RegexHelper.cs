using SimpleSeoMonitor.Domain.Shared.Helpers.Interfaces;
using System.Text.RegularExpressions;

namespace SimpleSeoMonitor.Domain.Shared.Helpers
{
    public sealed class RegexHelper : IRegexHelper
    {
        public bool IsValidUrl(string url, out string baseUrl)
        {
            string pattern = @"^(?:https?:\/\/)?([\w-]+\.[\w.-]+)(?:[\/\s]|$)";
            Match match = Regex.Match(url, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                baseUrl = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? match.Groups[1].Value : match.Groups[2].Value;
                return true;
            }

            baseUrl = string.Empty;
            return false;
        }
    }
}

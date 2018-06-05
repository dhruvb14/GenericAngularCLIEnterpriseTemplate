using System;

namespace Brownbag.Web.Extensions
{
    public static class SearchExtensions
    {
        public static bool CaseInsensitiveContains(this string text, string value)
        {
            if (text != null && value!= null)
            {
                return text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
            else
            {
                return false;
            }
        }
    }
}
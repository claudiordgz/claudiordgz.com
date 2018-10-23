using System;
using System.Text.RegularExpressions;

namespace ContentManager.Util
{
    public class UrlValidation
    {
        /// <summary>
        /// One nice formed and complete urls are valid https://a.co/one/two/three
        /// </summary>
        /// <param name="possibleUrl"></param>
        /// <param name="resultURI">variable to store string to url conversion</param>
        /// <returns>Flag declaring valid url</returns>
        public static bool ValidHttpURL(string possibleUrl, out Uri resultURI)
        {
            Uri.TryCreate(possibleUrl, UriKind.Absolute, out resultURI);
            if(Uri.IsWellFormedUriString(possibleUrl, UriKind.Absolute) && resultURI.Scheme == Uri.UriSchemeHttps)
            {
                Regex rgx = new Regex(@"^https\:\/\/(?!\-)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(\/\S*)?$");
                return rgx.IsMatch(possibleUrl);
            } else
            {
                return false;
            }
        }
    }
}

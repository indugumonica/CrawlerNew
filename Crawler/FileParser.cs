using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Crawler
{
    /// <summary>
    /// FileParser is internal class exposing Parsing API
    /// </summary>
    internal class FileParser
    {
        /// <summary>
        /// Downloads content from wiki API and then parses the history part using regex.
        /// For this assignment, we have to parse History section. This will not work for other urls.
        /// Since there is pattern to identify history alone, history is hardcoded here as regex.
        /// </summary>
        /// <param name="urlstring">The url string to be parsed</param>
        /// <returns></returns>
        internal string Parse(string urlstring)
        {
            WebClient client = new WebClient();
            string str;
            string output = "";
            using (Stream stream = client.OpenRead(urlstring))
            using (StreamReader reader = new StreamReader(stream))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                var result = serializer.Deserialize<Result>(new JsonTextReader(reader));

                foreach (var page in result.query.pages.Values)
                {
                    str = page.extract;
                    var match = Regex.Match(str, "History ==[\\s\\S]*Corporate affairs ==");
                    output = match.Groups[0].Value;
                    return output;
                }
            }
            return output;
        }
    }
}

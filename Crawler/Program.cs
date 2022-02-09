using System;
using System.IO;
using System.Net;
using System.Text.Json;
using static Crawler.FileParser;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Crawler
{
    class Program
    {
        /*
         * This is the driver code for executing Crawler API
         * Currently it hardcodes below inputs
         * 1. url to be crawled
         * 2. top n frequently occurred words
         * 3. List of words to exclude
         */
        static void Main(string[] args)
        {
            HashSet<string> excludewordlist = new HashSet<string>();
            excludewordlist.Add("a");
            excludewordlist.Add("or");
            excludewordlist.Add("an");
            excludewordlist.Add("is");
            string urlstring = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=Microsoft";
            int numOfFrequentWords = 10;
            var result = new Crawler().Crawl(urlstring, numOfFrequentWords,excludewordlist);
            foreach(var word in result)
            {
                Console.WriteLine(word);
            }







        }
    }

}

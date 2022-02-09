using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    /// <summary>
    /// Crawler is the public facing class exposing Crawl API
    /// </summary>
    public class Crawler
    {

        /// <summary>
        /// Crawls the given url and returns the top n frequent words after excluding given words in the list
        /// </summary>
        /// <param name="urlstring">url to be crawled</param>
        /// <param name="numOfFrequentWords">number of frequent words to be returned</param>
        /// <param name="wordsToExclude">List of words to be excluded</param>
        /// <returns>List of word and it's frequency</returns>
        public List<KeyValuePair<string,int>> Crawl(string urlstring, int numOfFrequentWords, HashSet<string> wordsToExclude)
        {
            var urldata = new FileParser().Parse(urlstring);
            Dictionary<string, int> output = new Dictionary<string, int>();
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            output = new WordFrequency().CalculateWordFrequency(urldata, wordsToExclude);

            int index = numOfFrequentWords;
            foreach (var word in output)
            {
                result.Add(word);
                index--;
                if (index == 0)
                {
                    break;
                }
            }
            return result;
        }
    }
}

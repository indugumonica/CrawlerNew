using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Crawler
{
    internal class WordFrequency
    {
        /// <summary>
        /// Given a string, splits into words and returns the frequency of each word.
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="ignoreWords">words to be ignored</param>
        /// <returns>dictionary of word and its frequency</returns>
        internal Dictionary<string, int> CalculateWordFrequency(string input, HashSet<string> ignoreWords)
        {
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();

            // Currently we are considering a valid word to contain alphabets.
            Regex rgx = new Regex("a-zA-Z");
            input = rgx.Replace(input, " ").ToLower();

            string[] words = input.Split(" ");
            foreach(string word in words)
            {
                if (ignoreWords.Contains(word))
                {
                    continue;
                }

                if (!wordOccurances.ContainsKey(word))
                {
                    wordOccurances.Add(word, 0);
                }
                wordOccurances[word]++;
            }
            return wordOccurances.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetUniqueWords
{
    public class UniqueFinder
    {
        private Dictionary<string, int> GetUniqueWords(string text)
        {
            string[] words = text.ToLower().Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?', '(', ')', '[', ']', '{', '}', '\t', '\n', '\r', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> UniqueWords = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (UniqueWords.ContainsKey(word))
                {
                    UniqueWords[word]++;
                }
                else
                {
                    UniqueWords.Add(word, 1);
                }
            }

            var SortedDictionary = UniqueWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return SortedDictionary;
        }

        public Dictionary<string, int> GetUniqueWordsMultiThread(string text)
        {
            string[] words = text.ToLower().Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?', '(', ')', '[', ']', '{', '}', '\t', '\n', '\r', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> UniqueWords = new Dictionary<string, int>();
            Parallel.ForEach(words, (word) =>
            {
                lock (UniqueWords) 
                {
                    if (UniqueWords.ContainsKey(word))
                    {
                        UniqueWords[word]++;
                    }
                    else
                    {
                        UniqueWords.Add(word, 1);
                    }
                }
            });

            var SortedDictionary = UniqueWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return SortedDictionary;
        }
    }
}
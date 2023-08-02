using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequencyCount
{
    class Program
    {
        static void Main(string[] args)
        
        {
            Console.WriteLine("Enter a sentence: ");
            string input = Console.ReadLine();
            Dictionary<string, int> wordFrequency = GetWordFrequency(input);

            Console.WriteLine("Word Frequency Count:");
            foreach (var kvp in wordFrequency)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        static Dictionary<string, int> GetWordFrequency(string input)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            string[] words = Regex.Split(input, @"\P{L}+");
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    string normalizedWord = word.ToLower();
                    if (wordFrequency.ContainsKey(normalizedWord))
                    {
                        wordFrequency[normalizedWord]++;
                    }
                    else
                    {
                        wordFrequency[normalizedWord] = 1;
                    }
                }
            }

            return wordFrequency;
        }
    }
}

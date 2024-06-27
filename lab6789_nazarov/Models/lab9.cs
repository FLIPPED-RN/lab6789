using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab6789_nazarov.Models
{
    public static class WordProcessor
    {
        public static string FindRareWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Введите строку.";
            }
            
            string cleanedInput = Regex.Replace(input.ToLower(), @"[^\w\s]", "");
            
            string[] words = cleanedInput.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            
            var wordFrequency = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }
            
            var rareWords = wordFrequency
                .Where(kvp => kvp.Value == wordFrequency.Values.Min())
                .Select(kvp => kvp.Key);
            
            return rareWords.OrderBy(w => w).FirstOrDefault();
        }
    }
}
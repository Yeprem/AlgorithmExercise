using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise
{
    public class Strings : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            IsAnagram();
            IsPalindromic(new string[] { "anna", "banana" });
            DoShareCommonSubstring(new string[] { "anna", "banana" });
            HowManyMovementsToMakeAnagram();
            CompressString();
            FindLongestSubstringWithXDistinctCharacters("karappa");
            CompareStringsWithBackspace();
        }

        private void IsAnagram()
        {
            string word1 = "abcdee";
            string word2 = "edeabc";

            Console.Write($"Is '{word1}' & '{word2}' anagram?");

            var result = false;

            if (word1.Length == word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    var index = word2.IndexOf(word1[i]);
                    if (index != -1)
                    {
                        word2 = word2.Substring(0, index) + word2.Substring(index + 1);
                    }
                    else
                    {
                        break;
                    }
                }

                result = word2.Length == 0;
            }

            Console.WriteLine($" -> {result}");
        }

        private void IsPalindromic(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                var subject = args[i];

                var startIndex = 0;
                var endIndex = subject.Length - 1;
                var result = false;

                while (startIndex < endIndex)
                {
                    if (Equals(subject[startIndex], subject[endIndex]))
                    {
                        startIndex++;
                        endIndex--;
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

                Console.WriteLine($"Is '{subject}' Palindromic? -> {result}");
            }
        }

        private void DoShareCommonSubstring(string[] args)
        {
            var index = 0;
            var length = 1;
            var s1 = args[0];
            var s2 = args[1];

            Console.Write($"Given two strings '{s1}' & '{s2}', determine if they share a common substring.");

            var result = false;

            while (!result && s1.Length > 0)
            {
                var substring = s1.Substring(index, length);
                if (s2.IndexOf(substring) > -1)
                {
                    result = true;
                }
                else
                {
                    s1 = s1.Replace(substring, "");
                }
            }

            Console.WriteLine($" -> {result}");
        }

        private void HowManyMovementsToMakeAnagram()
        {
            var list = new List<(string, string)>
            {
                ("ababadefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxz", "ababcdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxzdefghjklmnioprqustryxz"),
                ("banana", "anana"),
                ("ababa", "baaab")
            };

            for (int t = 0; t < list.Count; t++)
            {
                var word1 = list[t].Item1;
                var word2 = list[t].Item2;

                Console.Write($"Given two strings '{word1}' & '{word2}', how many movements required to make them anagram?");

                var start = DateTime.Now;

                var result = -1;

                if (word1.Length == word2.Length)
                {
                    for (int i = 0; i < word1.Length; i++)
                    {
                        var index = word2.IndexOf(word1[i]);
                        if (index != -1)
                        {
                            word2 = word2.Substring(0, index) + word2.Substring(index + 1);
                        }
                    }

                    result = word2.Length;
                }

                var end = DateTime.Now;

                Console.WriteLine($" -> {result}. Time Elapsed -> {(end - start).TotalMilliseconds} ms");
            }
        }

        private void CompressString()
        {
            /*
                If the compressed string is longer than the origianl, return the original string. 
            */

            Console.WriteLine($"Given a string, compress it by shortening every sequaence of the same character to that character followed by th number of repetitions.");

            var queryValues = new List<string>
            {
                "a",
                "aaa",
                "aaabbb",
                "aaabccc",
                "abc",
                "aaaabc"
            };

            foreach (var queryValue in queryValues)
            {
                var sb = new StringBuilder();
                var charInProgress = ' ';
                var count = 0;

                for (int i = 0; i < queryValue.Length; i++)
                {
                    var currentChar = queryValue[i];
                    if (charInProgress == ' ' || currentChar == charInProgress)
                    {
                        charInProgress = currentChar;
                        count++;
                    }
                    else
                    {
                        sb.Append($"{charInProgress}{count}");
                        charInProgress = currentChar;
                        count = 1;
                    }

                    if (i == queryValue.Length - 1)
                    {
                        sb.Append($"{charInProgress}{count}");
                    }
                }

                var compressedString = sb.ToString();
                var result = compressedString.Length > queryValue.Length ? queryValue : compressedString;

                Console.WriteLine($"Compression result of {queryValue} -> {result}");
            }
        }

        private void FindLongestSubstringWithXDistinctCharacters(string value)
        {
            /* Sliding window technique */

            var queryValues = new List<int> { 2, 3 };

            foreach (var queryValue in queryValues)
            {
                var start = 0;
                var end = 0;
                var hash = new Dictionary<char, int>();
                var sb = new StringBuilder();
                var result = string.Empty;
                var max = 0;

                while (end < value.Length)
                {
                    var current = value[end];
                    sb.Append(current);

                    if (hash.ContainsKey(current))
                    {
                        hash[current]++;
                    }
                    else
                    {
                        hash.Add(current, 1);
                    }

                    while (hash.Count > queryValue)
                    {
                        sb.Remove(0, 1);

                        var first = value[start++];
                        if (hash.TryGetValue(first, out int count) && count > 1)
                        {
                            hash[first]--;
                        }
                        else
                        {
                            hash.Remove(first);
                        }
                    }
                    
                    if (max <= sb.Length)
                    {
                        max = sb.Length;
                        result = sb.ToString();
                    }
                    end++;
                }

                Console.WriteLine($"Longest substring of {value} with {queryValue} distinct characters is {result}");
            }
        }

        private void CompareStringsWithBackspace()
        {
            var queryValues = new List<(string, string)>
            {
                ("ab#c", "ad#c"),
                ("ab##", "c#d#"),
                ("a#c", "b"),
            };

            foreach (var queryValue in queryValues)
            {
                var stack1 = new Stack<char>();
                var stack2 = new Stack<char>();
                var result = true;

                ApplyLogic(stack1, queryValue.Item1);
                ApplyLogic(stack2, queryValue.Item2);

                if (stack1.Count == stack2.Count)
                {
                    while (0 < stack1.Count && 0 < stack2.Count)
                    {
                        if (stack1.Pop() != stack2.Pop())
                        {
                            result = false;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Are {queryValue.Item1} and {queryValue.Item2} the same after backspaces applied? -> {result}");
            }


            void ApplyLogic(Stack<char> stack, string value)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    var current = value[i];

                    if (current != '#')
                    {
                        stack.Push(current);
                    }
                    else if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
            }
        }
    }
}

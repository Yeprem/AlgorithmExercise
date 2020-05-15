using System;

namespace AlgorithmExercise
{
    public class Strings : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            IsAnagram();
            IsPalindromic(new string[] { "anna", "banana" });
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
    }
}

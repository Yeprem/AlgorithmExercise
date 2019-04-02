using System;

namespace AlgorithmExercise
{
    public class Strings : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            IsAnagram();
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
                        result = false;
                    }
                }

                result = word2.Length == 0;
            }

            Console.WriteLine($" -> {result}");
        }
    }
}

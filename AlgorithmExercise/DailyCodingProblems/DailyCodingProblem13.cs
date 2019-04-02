using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem13 : DailyCodingProblemBase<string>
    {
        /*     
            Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.

            For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".              
        */

        protected override void RunIntrnal()
        {
            var value1 = "abcba";
            var numOfDistinctChar_value1 = 2;

            Console.WriteLine("The longest substring with {0} distinct characters is {1}", numOfDistinctChar_value1, RunLogic(value1, numOfDistinctChar_value1));
        }

        protected override string RunLogic(params object[] list)
        {
            string subject = (string)list[0];
            int numOfDistinctChar = (int)list[1];
            var startIndex = 0;
            var endIndex = startIndex + 1;
            var result = string.Empty;

            while (endIndex < subject.Length - 1)
            {
                var substring = subject.Substring(startIndex, endIndex);

                if (substring.Length < numOfDistinctChar)
                {
                    endIndex++;
                }
                else
                {
                    var hashset = new List<char>();
                    var distinctCharCount = 0;
                    for (int i = 0; i < substring.Length; i++)
                    {
                        if (!hashset.Contains(substring[i]))
                        {
                            distinctCharCount++;
                        }

                        hashset.Add(substring[i]);
                    }

                    if (distinctCharCount <= numOfDistinctChar)
                    {
                        if (string.IsNullOrWhiteSpace(result) || result.Length <= hashset.Count)
                        {
                            result = string.Join("", hashset);
                        }
                        endIndex++;
                    }
                    else
                    {
                        startIndex++;
                        endIndex = startIndex + 1;
                    }
                }
            }

            return result;
        }
    }
}

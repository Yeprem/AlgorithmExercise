using System;
using System.Text;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given a string, find the longest palindromic contiguous substring. If there are more than one with the maximum length, return any one.

        For example, the longest palindromic substring of "aabcdcb" is "bcdcb". The longest palindromic substring of "bananas" is "anana".          
    */

    public class DailyCodingProblem46 : DailyCodingProblemBase<string>
    {
        protected override void RunIntrnal()
        {
            string set = "bananas";
            Console.WriteLine($"The longest palindromic substring of [{set}] -> {RunLogic(set)}");
        }

        protected override string RunLogic(params object[] list)
        {
            char[] set = ((string)list[0]).ToCharArray();
            string result = string.Empty;
            StringBuilder subString = new StringBuilder();
            var numOfSubset = (int)Math.Pow(2, set.Length);

            for (int i = numOfSubset; i >= 0; i--)
            {
                subString.Clear();

                for (int j = 0; j < set.Length; j++)
                {
                    if ((i & (int)Math.Pow(2, j)) > 0)
                    {
                        subString.Append(set[j]);
                    }
                }

                if (!string.IsNullOrWhiteSpace(result) && subString.Length < result.Length)
                {
                    break;
                }
                else if (result.Length < subString.Length)
                {
                    int startIndex = 0;
                    int endIndex = subString.Length - 1;
                    bool isPalindromic = false;
                    while (startIndex < endIndex)
                    {
                        if (Equals(subString[startIndex], subString[endIndex]))
                        {
                            startIndex++;
                            endIndex--;
                            isPalindromic = true;
                        }
                        else
                        {
                            isPalindromic = false;
                            break;
                        }
                    }

                    if (isPalindromic)
                    {
                        result = subString.ToString();
                    }
                }
            }

            return result;
        }
    }
}

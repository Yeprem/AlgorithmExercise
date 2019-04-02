using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
     
        Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.

        For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:

        10 = max(10, 5, 2)
        7 = max(5, 2, 7)
        8 = max(2, 7, 8)
        8 = max(7, 8, 7)

        Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
         
    */

    public class DailyCodingProblem18 : DailyCodingProblemBase<List<int>>
    {
        protected override void RunIntrnal()
        {
            var value1 = new int[] { 10, 5, 2, 7, 8, 7 };
            var subarrayLength = 3;

            Console.WriteLine("Given array [{0}] and k = {1}, the result is [{2}]", string.Join(", ", value1), subarrayLength, string.Join(", ", RunLogic(value1, subarrayLength)));
        }

        protected override List<int> RunLogic(params object[] list)
        {
            int[] input = (int[])list[0];
            int subArrayLength = (int)list[1];
            List<int> result = new List<int>();

            int startIndex = 0;
            int endIndex = startIndex + subArrayLength;

            while (endIndex < input.Length + 1)
            {
                var maxValue = int.MinValue;
                for (int i = startIndex; i < endIndex; i++)
                {
                    var val = input[i];
                    if (val > maxValue)
                    {
                        maxValue = val;
                    }
                }

                result.Add(maxValue);
                startIndex++;
                endIndex++;
            }

            return result;
        }
    }
}

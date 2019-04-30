using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given an array of numbers, find the maximum sum of any contiguous subarray of the array. 
        Properties;
        - If the array contains all non-negative numbers, then the problem is trivial; the maximum subarray is the entire array.
        - If the array contains all non-positive numbers, then the solution is the number in the array with the smallest absolute value (or the empty subarray, if it is permitted).
        - Several different sub-arrays may have the same maximum sum.
        
        For example, given the array [34, -50, 42, 14, -5, 86], the maximum sum would be 137, since we would take elements 42, 14, -5, and 86.

        Given the array [-5, -1, -8, -9], the maximum sum would be 0, since we would not take any elements.
    */

    public class DailyCodingProblem49 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            int[] set = new int[] { 34, -50, 42, 14, -5, 86 };
            Console.WriteLine($"Given the array [{string.Join(", ", set)}] the maximum sum of any contiguous subarray is {RunLogic(set)}");
        }

        protected override int RunLogic(params object[] list)
        {
            int[] set = (int[])list[0];

            int tempResult = 0;
            int result = 0;
            var index = 0;
            var startIndex = 0;
            while (index < set.Length)
            {
                tempResult += set[index];
                index++;
                if (tempResult < 0)
                {
                    index = ++startIndex;
                    tempResult = 0;
                }
                else if(result < tempResult)
                {
                    result = tempResult;
                }
            }

            return result;
        }
    }
}

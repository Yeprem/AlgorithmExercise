using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given an array of integers where every integer occurs three times except for one integer, which only occurs once, find and return the non-duplicated integer.

        For example, given [6, 1, 3, 3, 3, 6, 6], return 1. Given [13, 19, 13, 13], return 19.

        Do this in O(N) time and O(1) space. 
    */

    public class DailyCodingProblem40 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            int[] value = { 6, 1, 3, 3, 3, 6, 6 };
            Console.WriteLine($"Non-duplicated value in  [{string.Join(", ", value)}] is {RunLogic(value)}");
        }

        protected override int RunLogic(params object[] list)
        {
            int[] value = (int[])list[0];
            int index = 1;
            int nonduplicateValueIndex = 0;

            while (index < value.Length)
            {
                if (value[nonduplicateValueIndex] == value[index])
                {
                    nonduplicateValueIndex++;
                    index = nonduplicateValueIndex + 1;
                }
                else
                {
                    index++;
                }
            }

            return value[nonduplicateValueIndex];
        }
    }
}

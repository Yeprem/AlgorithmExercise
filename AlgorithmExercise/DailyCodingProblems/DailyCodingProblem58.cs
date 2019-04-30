using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        An sorted array of integers was rotated an unknown number of times.

        Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.

        For example, given the array [13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).         
    */


    public class DailyCodingProblem58 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            int[] set = new int[] { 13, 18, 25, 2, 8, 10 };
            int value = 8;
            Console.WriteLine($"Given the array [{string.Join(", ", set)}], the index of value = {value} is {RunLogic(set, value)}");
        }

        protected override int RunLogic(params object[] list)
        {
            int[] set = (int[])list[0];
            int value = (int)list[1];

            int rIndex = set.Length - 1;
            int lIndex = 0;
            int result = 0;

            while (lIndex < rIndex)
            {
                if (set[lIndex] == value)
                {
                    result = lIndex;
                    break;
                }
                else if (set[rIndex] == value)
                {
                    result = rIndex;
                    break;
                }

                lIndex++;
                rIndex--;
            }

            return result;
        }
    }
}

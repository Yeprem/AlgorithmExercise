using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given an array of integers, return a new array such that each element at index i of 
        the new array is the product of all the numbers in the original array except the one at i.

        For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. 
                     If our input was [3, 2, 1], the expected output would be [2, 3, 6].
    */

    public class DailyCodingProblem2 : DailyCodingProblemBase<int[]>
    {
        protected override void RunIntrnal()
        {
            var value1 = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Array Generated from [{0}] = [{1}]", string.Join(", ", value1), string.Join(", ", RunLogic(value1)));

            var value2 = new int[] { 3, 2, 1 };
            Console.WriteLine("Array Generated from [{0}] = [{1}]", string.Join(", ", value2), string.Join(", ", RunLogic(value2)));
        }

        protected override int[] RunLogic(params object[] list)
        {
            int[] arr = (int[])list[0];

            //var result = RunLogicWithDivision(arr);
            var result = RunLogicWithoutDivision(arr);

            return result;
        }

        /*  O(n) */
        private static int[] RunLogicWithDivision(int[] arr)
        {
            var result = new int[arr.Length];

            var total = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                total *= arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = total / arr[i];
            }

            return result;
        }

        /*  O(n^2) */
        private static int[] RunLogicWithoutDivision(int[] arr)
        {
            var result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                Assign(i, arr[i]);
            }

            void Assign(int index, int value)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (i != index)
                    {
                        result[i] = result[i] == 0 ? value : result[i] * value;
                    }
                }
            }

            return result;
        }
    }
}

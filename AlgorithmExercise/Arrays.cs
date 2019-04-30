using System;
using System.Collections.Generic;

namespace AlgorithmExercise
{
    public class Arrays : AlgorithmBase
    {
        private readonly int[] _mainArray = new int[] { 1, 5, 3, 2, 4 };

        protected override void RunIntrnal()
        {
            FindLargestAndSmallest_UnSortedArray((int[])_mainArray.Clone());
            Reverse_InPlace((int[])_mainArray.Clone());
            FindMaxProfitInStockTrading((int[])_mainArray.Clone());
            FindUniquePathInGrid_Recursive();
            FindUniquePathInGrid_Iterative();
            RandomSort((int[])_mainArray.Clone());
            SubsetWithMaSum((int[])_mainArray.Clone());
        }

        /* O(logn) */
        private void FindLargestAndSmallest_UnSortedArray(int[] arr)
        {
            Console.Write($"Find Largest and Smallest Value in Unsorted Array - [{string.Join(", ", arr)}]");
            var start = 0;
            var end = arr.Length - 1;

            var max = int.MinValue;
            var min = int.MaxValue;

            while (start < end)
            {
                var rightSideValue = arr[start++];
                var leftSideValue = arr[end--];

                if (max < rightSideValue)
                {
                    max = rightSideValue;
                }

                if (min > rightSideValue)
                {
                    min = rightSideValue;
                }

                if (max < leftSideValue)
                {
                    max = leftSideValue;
                }

                if (min > leftSideValue)
                {
                    min = leftSideValue;
                }
            }

            Console.WriteLine($" -> Largest : [{max}] / Smallest : [{min}]");
        }

        /* O(logn) */
        private void Reverse_InPlace(int[] arr)
        {
            Console.Write($"Reversing array(in place) - [{string.Join(", ", arr)}]");

            var start = 0;
            var end = arr.Length - 1;

            while (start < end)
            {
                var temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;

                start++;
                end--;
            }

            Console.WriteLine($" -> [{string.Join(", ", arr)}]");
        }

        /* O(n) */
        private void FindMaxProfitInStockTrading(int[] arr)
        {
            // check DailyCodingProblem47
        }

        /* O(2^n) */
        private void FindUniquePathInGrid_Recursive()
        {
            var array = new int[3, 3];

            Console.Write($"Number of unqiue paths in {array.GetLength(0)} x {array.GetLength(1)} gird, from [{array.GetLength(0) - 1} ,{array.GetLength(1) - 1}] to [0, 0] (Recursive)");            

            var result = FindUniquePathInGrid_Helper(array.GetLength(0), array.GetLength(1));

            Console.WriteLine($" -> {result}");

            int FindUniquePathInGrid_Helper(int x, int y)
            {
                if (x == 1 || y == 1)
                {
                    return 1;
                }
                return FindUniquePathInGrid_Helper(x - 1, y) + FindUniquePathInGrid_Helper(x, y - 1);
            }
        }

        private void FindUniquePathInGrid_Iterative()
        {
            var array = new int[3, 3];

            Console.Write($"Number of unqiue paths in {array.GetLength(0)} x {array.GetLength(1)} gird, from [{array.GetLength(0) - 1} ,{array.GetLength(1) - 1}] to [0, 0] (Iteraative)");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, array.GetLength(1) - 1] = 1;
            }

            for (int i = 0; i < array.GetLength(1) - 1; i++)
            {
                array[array.GetLength(0) - 1, i] = 1;
            }

            for (int i = array.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = array.GetLength(1) - 2; j >= 0; j--)
                {
                    array[i, j] = array[i, j + 1] + array[i + 1, j];
                }
            }

            var result = array[0, 0];

            Console.WriteLine($" -> {result}");
        }

        private void RandomSort(int[] arr)
        {
            Console.Write($"Random Sort - [{string.Join(", ", arr)}]");

            for (int i = 0; i < arr.Length; i++)
            {
                var rnd = new Random().Next(i, arr.Length);
                var temp = arr[rnd];
                arr[rnd] = arr[i];
                arr[i] = temp;
            }

            Console.WriteLine($" -> [{string.Join(", ", arr)}]");
        }

        private void SubsetWithMaSum(int[] arr)
        {
            int subsetLength = 3;
            Console.Write($"Subset with {subsetLength} members that sum of item is greater than others [{string.Join(", ", arr)}]");

            List<int> result = null;
            var maxSum = 0;

            var totalNumberOfSubsets = (int)Math.Pow(2, arr.Length);

            for (int i = 0; i < totalNumberOfSubsets; i++)
            {
                var total = 0;
                var set = new List<int>();
                var numberOfElements = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if ((i & (int)Math.Pow(2, j)) > 0)
                    {
                        set.Add(arr[j]);
                        total += arr[j];
                        numberOfElements++;
                    }

                    if (numberOfElements == subsetLength)
                    {
                        break;
                    }
                }

                if (maxSum < total)
                {
                    maxSum = total;
                    result = set;
                }
            }

            Console.WriteLine($" -> [{string.Join(", ", result)}]");
        }
    }
}

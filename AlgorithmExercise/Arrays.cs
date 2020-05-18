using System;
using System.Collections.Generic;
using AlgorithmExercise.Utilities;

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
            SubsetWithMaxSum((int[])_mainArray.Clone());
            LeftRotation((int[])_mainArray.Clone());
            FindDuplicate();
            FindCommonElementsBetweenTwoArrays();
            FindCycle();
            FindSmallestNumberOfCoins();
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

        private void SubsetWithMaxSum(int[] arr)
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

        private void LeftRotation(int[] arr)
        {
            int count = 4;
            Console.Write($"Array {string.Join(", ", arr)} will be rotated {count} times");

            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int newIndex = arr.Length + (i - count);
                if (newIndex >= arr.Length)
                {
                    newIndex = newIndex - arr.Length;
                }
                result[newIndex] = arr[i];
            }

            Console.WriteLine($" -> {string.Join(", ", result)}");
        }

        private void FindDuplicate()
        {
            var array = new int[] { 1, 4, 5, 6, 2, 4, 6, 1 };

            Console.WriteLine($"Find Duplicate - [{string.Join(", ", array)}]");

            var hash = new HashSet<int>();
            var duplicate = -1;

            for (int i = 0; i < array.Length; i++)
            {
                var current = array[i];

                if (hash.Contains(current))
                {
                    duplicate = current;
                    break;
                }
                else
                {
                    hash.Add(current);
                }
            }

            Console.WriteLine($"Duplicate {duplicate.ToString()}");
        }

        private void FindCommonElementsBetweenTwoArrays()
        {
            var arr1 = new int[] { 1, 5, 12, 3, -15, 52 };
            var arr2 = new int[] { 3, 1, 6, 5, 57, 13, 17 };

            Console.Write($"Find elemets in common between these arrays - [{string.Join(", ", arr1)}] & [{string.Join(", ", arr2)}] -> ");

            var set = new HashSet<int>();

            for (int i = 0; i < arr1.Length; i++)
            {
                set.Add(arr1[i]);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                if (set.Contains(arr2[i]))
                {
                    Console.Write($"{arr2[i]} ");
                }
            }

        }

        private void FindCycle()
        {
            /*             
                Directives;
                G -> straight
                R -> turn right
                L -> turn left             
             */

            Console.WriteLine("");

            var commands = new List<string> { "GRRR", "GRLL" };

            for (int a = 0; a < commands.Count; a++)
            {
                var command = commands[a];

                Console.Write($"Is {command} creates cycle?");

                var directionsWithIterator = new Dictionary<char, short> { { 'U', -1 }, { 'D', 1 }, { 'R', 1 }, { 'L', -1 } };
                var visitedPoints = new HashSet<(short, short)> { (0,0) };
                var direction = ' ';
                short xPoint = 0;
                short yPoint = 0;
                bool isCycleExist = false;

                for (int i = 0; i < command.Length; i++)
                {
                    var directive = command[i];
                    
                    direction = SetDirection(directive, direction);

                    var iterator = directionsWithIterator[direction];

                    if (direction == 'U' || direction == 'D')
                    {
                        yPoint += iterator;
                    }
                    else
                    {
                        xPoint += iterator;
                    }

                    if (visitedPoints.Contains((xPoint, yPoint)))
                    {
                        isCycleExist = true;
                        break;
                    }
                    else
                    {
                        visitedPoints.Add((xPoint, yPoint));
                    }
                }                

                Console.WriteLine($" -> {isCycleExist}");

            }   
            
            char SetDirection(char directive, char direction) {

                var result = direction;

                if (direction == 'U')
                {
                    result = directive == 'R' ?  'R' : 'L';
                }
                else if (direction == 'D')
                {
                    result = directive == 'R' ? 'L' : 'R';
                }
                else if (direction == 'R')
                {
                    result = directive == 'R' ? 'D' : 'U';
                }
                else if (direction == 'L')
                {
                    result = directive == 'R' ? 'U' : 'D';
                }
                else
                {
                    switch (directive)
                    {
                        case 'G':
                            result = 'R';
                            break;
                        case 'R':
                            result = 'D';
                            break;
                        case 'L':
                            result = 'U';
                            break;
                    }
                }

                return result;
            }
        }

        private void FindSmallestNumberOfCoins()
        {
            var queryValues = new List<double> { 5.75, 31.26, 0.99 };
            var coinSystem = new List<double> { 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2 }; // British coin system

            foreach (var queryValue in queryValues)
            {
                Console.Write($"Smallest number of coins required to find the sum of {queryValue} is ");

                var numberOfCoinsRequired = 0;
                var coinIndex = coinSystem.Count - 1;
                var sum = queryValue * 100; // To make division easy

                while (0 < sum)
                {
                    var coinValue = coinSystem[coinIndex] * 100;

                    if (coinValue > sum)
                    {
                        coinIndex--;
                        continue;
                    }                    

                    var numOfCoin = Convert.ToInt32(Math.Floor(sum / coinValue));
                    sum -= coinValue * numOfCoin;
                    numberOfCoinsRequired += numOfCoin;
                }

                Console.WriteLine(numberOfCoinsRequired);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
            FindMaximumSumOfASubarray((int[])_mainArray.Clone());
            SquareASortedArray();
            FindTripletsWithZeroSum();
            IsCircularArray_WithTwoMovementDirection();
            IsCircularArray_WithOneMovementDirection();
            FindSubsetOfTheArray((int[])_mainArray.Clone());
            AddNumberToANumberInArrayRepresentation();
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

        private void FindMaximumSumOfASubarray(int[] arr)
        {
            /* Sliding Window concept implemented */

            var queryValues = new List<int> { 3 };

            foreach (var queryValue in queryValues)
            {
                var start = 0;
                var sum = 0;
                var max = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];

                    if (i >= queryValue - 1)
                    {
                        max = Math.Max(sum, max);
                        sum -= arr[start++];                        
                    }
                }

                Console.WriteLine($"Maximum sum of a subarray of size {queryValue} of [{string.Join(", ", arr)}] is {max}");
            }
        }

        private void SquareASortedArray()
        {
            /* Two Pointer technique */

            var queryValues = new List<int[]>
            {
                new int[]{ -4, -1, 0, 3, 10 },
                new int[]{ -7, -3, 2, 3, 11 }
            };

            foreach (var queryValue in queryValues)
            {
                var positivePointer = 0; // Pointer 1
                var negativePointer = 0; // Pointer 2
                var result = new int[queryValue.Length];

                while (queryValue[positivePointer] < 0)
                {
                    positivePointer++;
                }

                negativePointer = positivePointer - 1;

                var index = 0;
                while (positivePointer < queryValue.Length && negativePointer >= 0)
                {
                    if (queryValue[positivePointer] * queryValue[positivePointer] > queryValue[negativePointer] * queryValue[negativePointer])
                    {
                        result[index++] = queryValue[negativePointer] * queryValue[negativePointer];
                        negativePointer--;
                    }
                    else
                    {
                        result[index++] = queryValue[positivePointer] * queryValue[positivePointer];
                        positivePointer++;
                    }
                }

                while (positivePointer < queryValue.Length)
                {
                    result[index++] = queryValue[positivePointer] * queryValue[positivePointer];
                    positivePointer++;
                }

                while (0 < negativePointer)
                {
                    result[index++] = queryValue[negativePointer] * queryValue[negativePointer];
                    negativePointer--;
                }

                Console.WriteLine($"Square of sorted array [{string.Join(", ", queryValue)}] is [{string.Join(", ", result)}]");
            }
        }

        private void FindTripletsWithZeroSum()
        {
            /* Two Pointer technique */

            var queryValues = new List<int[]>
            {
                new []{-1, 0, 1, 2, -1, -4}
            };

            foreach (var queryValue in queryValues)
            {
                var result = new List<string>();
                Sort(queryValue);

                for (int i = 0; i < queryValue.Length; i++)
                {
                    int start = i + 1;
                    int end = queryValue.Length - 1;

                    if (i > 0 && queryValue[i] == queryValue[i - 1])
                    {
                        //if values are consecutive, they will provide same triplet
                        continue;
                    }

                    while (start < end)
                    {
                        if (end < queryValue.Length - 1 && queryValue[end] == queryValue[end + 1])
                        {
                            //if values are consecutive, they will provide same triplet
                            end--;
                            continue;
                        }

                        if (queryValue[i] + queryValue[start] + queryValue[end] == 0)
                        {
                            result.Add($"[{queryValue[i]}, {queryValue[start]}, {queryValue[end]}]");
                            start++;
                            end--;
                        }
                        else if (queryValue[i] + queryValue[start] + queryValue[end] < 0)
                        {
                            start++;
                        }
                        else
                        {
                            end--;
                        }
                    }
                }

                Console.WriteLine($"Triplets with zero sum in [{string.Join(", ", queryValue)}] is [{string.Join(", ", result)}]");
            }


            void Sort(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - 1 - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            var temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
        }

        private void IsCircularArray_WithTwoMovementDirection()
        {
            /*
                If a number k at an index is positive, then move forward k steps. Conversely, if it's negative (-k), move backward k steps. 
                Since the array is circular, you may assume that the last element's next element is the first element, and the first element's previous element is the last element.

                Determine if there is a loop (or a cycle) in nums. A cycle must start and end at the same index and the cycle's length > 1. 
                Furthermore, movements in a cycle must all follow a single direction. In other words, a cycle must not consist of both forward and backward movements.
             */

            var queryValues = new List<int[]>
            {
                new int[]{ 2, -1, 1, 2, 2 },
                new int[]{ -1, 2 },
                new int[]{ -2, 1, -1, -2, -2 },
                new int[]{ 1, 2, -1, 7, -2 },
                new int[]{ 2, 1 }
            };

            foreach (var queryValue in queryValues)
            {
                var indexHash = new HashSet<int>();
                var result = false;

                var index = 0;
                int? firstMovement = default;
                int movement = 0;

                while (!firstMovement.HasValue || firstMovement.Value == movement)
                {
                    var current = queryValue[index];
                    var currentMovement = current > 0 ? 1 : -1;

                    if (!firstMovement.HasValue)
                    {
                        firstMovement = currentMovement;
                    }

                    movement = currentMovement;

                    if (indexHash.Contains(index))
                    {
                        result = indexHash.Count > 1;
                        break;
                    }

                    indexHash.Add(index);

                    if (current > queryValue.Length)
                    {
                        current = current % queryValue.Length;
                    }

                    if (index + current >= queryValue.Length)
                    {
                        index = (index + current) - queryValue.Length;
                    }
                    else if (index + current < 0)
                    {
                        index = queryValue.Length - Math.Abs((index - Math.Abs(current)));
                    }
                    else
                    {
                        index += current;
                    }
                }

                Console.WriteLine($"Is [{string.Join(", ", queryValue)}] circular? -> {result}");
            }
        }

        private void IsCircularArray_WithOneMovementDirection()
        {
            /* Fast and slow pointers */
            /* 
                all values are depicting an index in array. If there is a value inn array  
                which is greater than the length of the queue, that means here is no cycle.
            */

            var queryValues = new List<int[]>
            {
                new int[]{ 1, 2, 1 ,3 ,4 },
                new int[]{ 1, 2, 5, 3, 4, 8 }
            };

            foreach (var queryValue in queryValues)
            {
                var result = true;

                var p1 = 0;
                var p2 = 2;
                var moveCount = 0;

                while (p1 != p2)
                {
                    if (p2 > queryValue.Length - 1)
                    {
                        result = false;
                        break;
                    }

                    p2 = queryValue[p2];
                    moveCount++;

                    if (moveCount == 2)
                    {
                        moveCount = 0;
                        p1 = queryValue[p1];
                    }
                }

                Console.WriteLine($"Is [{string.Join(", ", queryValue)}] circular? -> {result}");
            }
        }

        private void FindSubsetOfTheArray(int[] arr)
        {
            var set = arr.ToList();

            var result = new List<List<int>>();

            result.Add(new List<int>());

            for (int i = 0; i < set.Count; i++)
            {
                var current = arr[i];
                var temp = new List<List<int>>();

                for (int t = 0; t < result.Count; t++)
                {
                    var copy = new List<int>(result[t]);
                    copy.Add(current);
                    temp.Add(copy);
                }

                result.AddRange(temp);
            }

            Console.WriteLine($" Array [{string.Join(", ", set)}] has {result.Count} subsets;");
            foreach (var item in result)
            {
                Console.WriteLine($"[{string.Join(", ", item)}]");
            }
        }

        private void AddNumberToANumberInArrayRepresentation()
        {
            var baseNum = new int[] { 1, 3, 2, 4 };

            var queryValues = new List<int> { 1, 15, 120, 106 };

            foreach (var queryValue in queryValues)
            {
                var remaining = queryValue;
                var result = new int[baseNum.Length];

                for (int i = baseNum.Length - 1; 0 <= i; i--)
                {
                    var current = baseNum[i];
                    var newNum = current + remaining;
                    
                    if (newNum > 10)
                    {
                        remaining = newNum / 10;
                        newNum %= 10;
                    }
                    else
                    {
                        remaining = 0;
                    }

                    result[i] = newNum;
                }

                Console.WriteLine($"Result of Addition of {queryValue} to Array Representation of Number {string.Join("", baseNum)} is {string.Join("", result)}");
            }
        }
    }
}
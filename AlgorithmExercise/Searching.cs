using System;

namespace AlgorithmExercise
{
    public class Searching : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            BinarySearch();
        }

        private void BinarySearch()
        {
            int[] array = new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Binary Search \nFind Missing Number in [{string.Join(", ", array)}]");

            var start = 0;
            var end = array.Length - 1;
            var mid = 0;
            while (start <= end)
            {
                mid = (start + end) / 2;

                if (array[mid] == mid)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            var result = array[mid] == mid ? array.Length : mid;

            Console.WriteLine($"Missing Number in [{string.Join(", ", array)}] is {result}");
            Console.WriteLine();
        }
    }
}

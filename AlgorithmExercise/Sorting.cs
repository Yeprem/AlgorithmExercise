using System;

namespace AlgorithmExercise
{
    public class Sorting : AlgorithmBase
    {
        private readonly int[] _mainArray = new int[] { 1, 5, 3, 2, 4 };

        protected override void RunIntrnal()
        {
            Console.WriteLine($"Array going to be sorted [{string.Join(", ", _mainArray)}]");
            SelectionSort((int[])_mainArray.Clone());
            BubbleSort((int[])_mainArray.Clone());
            QuickSort((int[])_mainArray.Clone());
        }

        private void SelectionSort(int[] arr)
        {
            Console.WriteLine("Selection Sort");

            for (int i = 0; i < arr.Length; i++)
            {
                var minValue = int.MaxValue;
                var minIndex = arr.Length;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < minValue)
                    {
                        minValue = arr[j];
                        minIndex = j;
                    }
                }

                var temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            Console.WriteLine($"-> [{string.Join(", ", arr)}]");
        }

        private void BubbleSort(int[] arr)
        {
            Console.WriteLine("Bubble Sort");

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

            Console.WriteLine($"-> [{string.Join(", ", arr)}]");
        }

        private void QuickSort(int[] arr)
        {
            Console.WriteLine("Quick Sort");

            QuickSort_Internal(arr, 0, arr.Length - 1);

            Console.WriteLine($"-> [{string.Join(", ", arr)}]");

            void QuickSort_Internal(int[] array, int start, int end)
            {
                if (start < end)
                {
                    var pivot = QuickSort_Pivot(array, start, end);

                    QuickSort_Internal(array, start, pivot - 1);
                    QuickSort_Internal(array, pivot + 1, end);
                }

                int QuickSort_Pivot(int[] a, int s, int e)
                {
                    var pivot = a[e];
                    var index = s;

                    for (int i = s; i < e; i++)
                    {
                        if (a[i] <= pivot)
                        {
                            int temp = a[i];
                            a[i] = a[index];
                            a[index] = temp;

                            index++;
                        }
                    }

                    var temp1 = a[index];
                    a[index] = a[e];
                    a[e] = temp1;

                    return index;
                }
            }
        }
    }
}

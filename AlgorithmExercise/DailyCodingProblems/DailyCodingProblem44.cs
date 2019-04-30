using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        We can determine how "out of order" an array A is by counting the number of inversions it has. Two elements A[i] and A[j] form an inversion if A[i] > A[j] but i < j. That is, a smaller element appears after a larger element.

        Given an array, count the number of inversions it has. Do this faster than O(N^2) time.

        You may assume each element in the array is distinct.

        For example, a sorted list has zero inversions. The array [2, 4, 1, 3, 5] has three inversions: (2, 1), (4, 1), and (4, 3). The array [5, 4, 3, 2, 1] has ten inversions: every distinct pair forms an inversion.          
    */

    public class DailyCodingProblem44 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            var set = new int[] { 2, 4, 1, 3, 5 };
            Console.WriteLine($"The number of inversion in [{string.Join(", ", set)}] -> {RunLogic(set)}");
        }

        protected override int RunLogic(params object[] list)
        {
            int[] set = (int[])list[0];

            int startIndex = 0;
            int endIndex = startIndex + 1;
            int result = 0;
            int lastVisitedMaxStartIndex = 0;
            bool onlyIncreaseStartIndex = false;
            while (endIndex < set.Length)
            {
                if (set[startIndex] > set[endIndex] && startIndex < endIndex)
                {
                    result++;

                    if (onlyIncreaseStartIndex)
                    {
                        if (endIndex < set.Length - 1)
                        {
                            endIndex++;
                        }
                        else
                        {
                            startIndex++;
                            endIndex = startIndex + 1;
                        }
                    }
                    else
                    {
                        if (startIndex > 0)
                        {
                            startIndex--;
                        }
                        else
                        {
                            startIndex++;
                            if (endIndex < set.Length - 1)
                            {
                                endIndex++;
                            }
                            else
                            {
                                startIndex = lastVisitedMaxStartIndex + 1;
                                endIndex = startIndex + 1;
                                onlyIncreaseStartIndex = true;
                            }
                        }

                        if (lastVisitedMaxStartIndex < startIndex)
                        {
                            lastVisitedMaxStartIndex = startIndex;
                        }
                    }
                }
                else
                {
                    startIndex++;
                    if (endIndex < set.Length - 1)
                    {
                        endIndex++;
                    }
                    else
                    {
                        endIndex = startIndex + 1;
                    }
                }
            }

            return result;
        }
    }
}

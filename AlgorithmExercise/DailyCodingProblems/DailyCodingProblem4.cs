using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem4 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            var value1 = new int[] { 3, 4, -1, 1 };
            Console.WriteLine("Missing Lowest Positive Integer in [{0}] = {1}", string.Join(", ", value1), RunLogic(value1));

            var value2 = new int[] { 1, 2, 0 };
            Console.WriteLine("Missing Lowest Positive Integer in [{0}] = {1}", string.Join(", ", value2), RunLogic(value2));
        }

        protected override int RunLogic(params object[] list)
        {
            int[] array = (int[])list[0];
            var hashSetExisting = new HashSet<int>();
            var hashSetMissing = new HashSet<int>();
            var maxPositive = 0;

            for (int i = 0; i < array.Length; i++)
            {
                hashSetExisting.Add(array[i]);

                if (array[i] > 1)
                {
                    if (hashSetMissing.Contains(array[i]))
                    {
                        hashSetMissing.Remove(array[i]);
                    }
                    else if (!hashSetExisting.Contains(array[i] - 1))
                    {
                        hashSetMissing.Add(array[i] - 1);
                    }

                    if (maxPositive < array[i])
                    {
                        maxPositive = array[i];
                    }
                }
            }

            var resultFromHashset = hashSetMissing.FirstOrDefault();
            var result = resultFromHashset > 0 ? resultFromHashset : maxPositive + 1;

            return result;
        }
    }
}

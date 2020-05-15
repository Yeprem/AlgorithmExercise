using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.

        For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.

        You may also use a list or array to represent a set.
    */

    public class DailyCodingProblem37 : DailyCodingProblemBase<List<string>>
    {
        protected override void RunIntrnal()
        {
            var value = new int[] { 1, 2, 3 };
            Console.WriteLine($"Subsets of [{string.Join(", ", value)}] = [{string.Join(", ", RunLogic(value))}]");
        }

        protected override List<string> RunLogic(params object[] list)
        {
            int[] arr = (int[])list[0];

            List<string> result = new List<string>();
            var totalNumberOfSubsets = (int)Math.Pow(2, arr.Length);
            var subset = new List<string>();

            for (int i = 0; i < totalNumberOfSubsets; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if ((i & (int)Math.Pow(2, j)) > 0)
                    {
                        subset.Add(arr[j].ToString());
                    }
                }

                result.Add($"[{string.Join(", ", subset)}]");
                subset.Clear();
            }

            return result;

            /*
                & -> bitwise comparison
                The way it works here;
                
                i = 0 -> binary = 0000
                j = 0
                2^j = 1 -> binary = 0001
                i & 2^j = 0
                .
                .


                i = 1 -> binary = 0001
                j = 0
                2^j = 1 -> binary = 0001
                i & 2^j = 1 -> because it is greater than zero, the item at index j will be added to the set
                .
                .     
             
             */
        }
    }
}

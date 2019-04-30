using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem42 : DailyCodingProblemBase<string>
    {
        /*
            Given a list of integers S and a target number k, write a function that returns a subset of S that adds up to k. If such a subset cannot be made, then return null.

            Integers can appear more than once in the list. You may assume all numbers in the list are positive.

            For example, given S = [12, 1, 61, 5, 9, 2] and k = 24, return [12, 9, 2, 1] since it sums up to 24.             
        */

        protected override void RunIntrnal()
        {
            var set = new int[] { 12, 1, 61, 5, 9, 2 };
            var targetSum = 24;
            Console.WriteLine($"Subsets of [{string.Join(", ", set)}] that sum equals {targetSum} -> [{string.Join(", ", RunLogic(set, targetSum))}]");
        }

        protected override string RunLogic(params object[] list)
        {
            int[] set = (int[])list[0];
            int targetSum = (int)list[1];

            var numOfSubSets = (int)Math.Pow(2, set.Length);
            List<int> subset = new List<int>();

            for (int i = 0; i < numOfSubSets; i++)
            {
                int sumOfSubset = 0;

                for (int j = 0; j < set.Length; j++)
                {
                    if ((i & (int)Math.Pow(2, j)) > 0)
                    {
                        sumOfSubset += set[j];

                        if (sumOfSubset > targetSum)
                        {
                            sumOfSubset = 0;
                            subset.Clear();
                            break;
                        }
                        else
                        {
                            subset.Add(set[j]);
                        }
                    }                    
                }

                if (sumOfSubset == targetSum)
                {
                    break;
                }
                else
                {
                    subset.Clear();
                }
            }

            return subset.Count > 0 ? $"[{string.Join(", ", subset)}]" : "[]";
        }
    }
}

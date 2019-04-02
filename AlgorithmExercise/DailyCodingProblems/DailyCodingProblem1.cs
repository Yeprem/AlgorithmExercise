using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem1 : DailyCodingProblemBase<bool>
    {
        /*
            Given a list of numbers and a number k, return whether any two numbers from the list add up to k. 
        */

        protected override void RunIntrnal()
        {
            int[] arr = { 10, 15, 3, 7 };

            int value1 = 17;
            Console.WriteLine($"Whether Any Two Numbers From The List Add Up To {value1} = {RunLogic(arr, value1)}");

            int value2 = 20;
            Console.WriteLine($"Whether Any Two Numbers From The List Add Up To {value2} = {RunLogic(arr, value2)}");
        }

        protected override bool RunLogic(params object[] list)
        {
            int[] arr = (int[])list[0];
            int k = (int)list[1];

            var result = false;
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(arr[i]))
                {
                    result = true;
                    break;
                }
                else
                {
                    var diff = k - arr[i];
                    if (diff > 0)
                    {
                        set.Add(diff);
                    }
                }
            }

            return result;
        }
    }
}

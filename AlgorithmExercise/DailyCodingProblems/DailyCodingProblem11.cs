using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem11 : DailyCodingProblemBase<string>
    {
        protected override void RunIntrnal()
        {
            var set = new string[] { "dog", "deer", "deal" };

            var value1 = "de";

            Console.WriteLine("Autocomplete Result for {0} in [{1}] = {2}", value1, string.Join(", ", set), RunLogic(value1, set));

            var value2 = "a";
            Console.WriteLine("Autocomplete Result for {0} in [{1}] = {2}", value2, string.Join(", ", set), RunLogic(value2, set));
        }

        protected override string RunLogic(params object[] list)
        {
            string input = (string)list[0];
            string[] array = (string[])list[1];
            var set = new Dictionary<string, List<string>>();

            for (int i = 0; i < array.Length; i++)
            {
                var current = array[i];
                var key = current.Substring(0, input.Length);

                if (set.ContainsKey(key))
                {
                    set[key].Add(current);
                }
                else
                {
                    set[key] = new List<string> { current };
                }
            }

            var result = set.ContainsKey(input) ? $"[{string.Join(",", set[input])}]" : "[]";
            return result;
        }
    }
}

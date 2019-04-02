using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.

        Do this in linear time and in-place.

        For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'].        
         
    */

    public class DailyCodingProblem35 : DailyCodingProblemBase<string[]>
    {
        protected override void RunIntrnal()
        {
            string[] value = { "G", "B", "R", "R", "B", "R", "G" };
            Console.WriteLine($"Z to A ordered version of [{string.Join(", ", value)}] = [{string.Join(", ", RunLogic(value))}]");
        }

        protected override string[] RunLogic(params object[] list)
        {
            int index = 1;
            string[] value = (string[])list;

            while (index < value.Length)
            {
                if (value[index - 1].CompareTo(value[index]) < 0)
                {
                    var temp = value[index - 1];
                    value[index - 1] = value[index];
                    value[index] = temp;

                    if (index > 1)
                    {
                        index--;
                    }
                }
                else
                {
                    index++;
                }
            }

            return value;
        }
    }
}

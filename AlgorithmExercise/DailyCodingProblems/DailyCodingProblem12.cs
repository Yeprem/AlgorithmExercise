using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem12 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            var set = new int[] { 1, 2 };
            var value1 = 4;
            Console.WriteLine("Number of unqiue ways to climb {0} stairs with {1} by Recursion = {2}", value1, string.Join(" or ", set), RunLogic_Recursive(value1, set));
            Console.WriteLine("Number of unqiue ways to climb {0} stairs with {1} by Memoization = {2}", value1, string.Join(" or ", set), RunLogic_Memoization(value1, set));
            Console.WriteLine("Number of unqiue ways to climb {0} stairs with {1} by Tabulation = {2}", value1, string.Join(" or ", set), RunLogic_Tabulation(value1, set));
        }

        protected override int RunLogic(params object[] list)
        {
            throw new NotImplementedException();
        }

        public int RunLogic_Recursive(int numOfstairs, int[] availableMoves)
        {
            var result = RunLogic_Recursive_Helper(numOfstairs, availableMoves);
            return result;
        }
        /* O(2^n) */
        private int RunLogic_Recursive_Helper(int numOfstairs, int[] availableMoves)
        {
            if (numOfstairs <= 1)
            {
                return 1;
            }
            else
            {
                var result = 0;

                for (int i = 0; i < availableMoves.Length; i++)
                {
                    if (availableMoves[i] <= numOfstairs)
                    {
                        result += RunLogic_Recursive_Helper(numOfstairs - availableMoves[i], availableMoves);
                    }
                }

                return result;
            }
        }

        /* O(N) */

        public int RunLogic_Tabulation(int numOfstairs, int[] availableMoves)
        {
            var resultSet = new int[numOfstairs + 1];
            resultSet[0] = 1;
            resultSet[1] = 1;

            for (int i = 2; i <= numOfstairs; i++)
            {
                var tempResult = 0;

                for (int j = 0; j < availableMoves.Length; j++)
                {
                    if (availableMoves[j] <= i)
                    {
                        tempResult += resultSet[i - availableMoves[j]];
                    }
                }

                resultSet[i] = tempResult;
            }

            return resultSet[numOfstairs];
        }

        /* O(2^n) */
        public int RunLogic_Memoization(int numOfstairs, int[] availableMoves)
        {
            var resultSet = new int[numOfstairs + 1];

            var result = RunLogic_Memoization_Helper(numOfstairs, availableMoves, resultSet);

            return result;
        }

        private int RunLogic_Memoization_Helper(int numOfstairs, int[] availableMoves, int[] resultSet)
        {
            if (resultSet[numOfstairs] > 0)
            {
                return resultSet[numOfstairs];
            }
            else if (numOfstairs <= 1)
            {
                resultSet[numOfstairs] = 1;
            }
            else
            {
                var result = 0;
                for (int i = 0; i < availableMoves.Length; i++)
                {
                    if (availableMoves[i] <= numOfstairs)
                    {
                        result += RunLogic_Memoization_Helper(numOfstairs - availableMoves[i], availableMoves, resultSet);
                    }
                }

                resultSet[numOfstairs] = result;
            }

            return resultSet[numOfstairs];
        }
    }
}

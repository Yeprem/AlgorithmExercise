using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given a array of numbers representing the stock prices of a company in chronological order, write a function that calculates the maximum profit you could have made from buying and selling that stock once. You must buy before you can sell it.

        For example, given [9, 11, 8, 5, 7, 10], you should return 5, since you could buy the stock at 5 dollars and sell it at 10 dollars. 
    */


    public class DailyCodingProblem47 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {   
            int[] set = new int[] { 9, 11, 8, 5, 7, 10 };
            Console.WriteLine($"Maximum profit that you can make from buy/sell that stock is in [{string.Join(", ", set)}] is {RunLogic(set)}");
        }

        protected override int RunLogic(params object[] list)
        {
            int[] set = (int[])list[0];

            int buyIndex = 0;
            int sellIndex = buyIndex + 1;
            int profit = -1;

            while (sellIndex < set.Length)
            {
                int diff = set[sellIndex] - set[buyIndex];

                if (profit <= diff)
                {
                    profit = diff;
                    sellIndex++;
                }
                else
                {
                    buyIndex++;
                    sellIndex = buyIndex + 1;
                }
            }

            return profit;
        }
    }
}

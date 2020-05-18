using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise
{
    public class Matrixes : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            OrderedMatrixSearch();
        }

        private void OrderedMatrixSearch()
        {
            var set = new short[,]
            {
                { 0, 1, 2, 3 },
                { 4, 5, 6, 7 },
                { 8, 9, 10, 11 },
                { 12, 13, 14, 15 }
            };

            var searchValues = new List<short> { 0, -1, 9, 16 };

            foreach (var searchValue in searchValues)
            {
                Console.Write($"Given an {set.GetLength(0)}x{set.GetLength(1)} array where all rows and columns are in sorted order, is {searchValue} exists?");

                var row = 0;
                var column = set.GetLength(1) - 1;
                var result = false;

                while (row < set.GetLength(0) && column >= 0)
                {
                    if (set[row, column] > searchValue)
                    {
                        column--;
                    }
                    else if (set[row, column] < searchValue)
                    {
                        row++;
                    }
                    else
                    {
                        result = true;
                        break;
                    }
                }

                Console.WriteLine($"-> {result}");
            }
        }
    }
}

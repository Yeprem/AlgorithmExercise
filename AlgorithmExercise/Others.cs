using System;
using System.Collections.Generic;

namespace AlgorithmExercise
{
    public class Others : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            FindPageCountNeedsToBeTurned(9, 5);
            IntervalIntersection();
        }

        private void FindPageCountNeedsToBeTurned(int pageCount, int pageRequested)
        {
            /* To reach first page you don't need to turn a page */
            
            var result = 0;

            if (pageRequested > 1)
            {
                var middlePage = pageCount / 2;

                if (pageRequested < middlePage)
                {
                    result = Convert.ToInt32(Math.Floor(pageCount / 2.0));
                }
                else
                {
                    pageCount = pageCount % 2 > 0 ? pageCount : pageCount - 1;
                    result = Convert.ToInt32(Math.Floor((pageCount - pageRequested) / 2.0));
                }
            }

            Console.WriteLine($"How many pages needs to be turned to reach page {pageRequested} in a book with {pageCount} pages? -> {result}");            
        }

        private void IntervalIntersection()
        {
            /*
                Each list of intervals is pairwise disjoint and in sorted order.
            */

            var a = new List<(int, int)> { (0, 2), (5, 10), (13, 23), (24, 25) };
            var b = new List<(int, int)> { (1, 5), (8, 12), (15, 24), (25, 26) };

            var aIndex = 0;
            var bIndex = 0;
            var result = new List<string>();

            while (aIndex < a.Count && bIndex < b.Count)
            {
                var currentA = a[aIndex];
                var currentB = b[bIndex];

                if (currentA.Item2 >= currentB.Item1 && currentB.Item2>= currentA.Item1) // This condition needs to be met to have an interval
                {
                    var firstPoint = Math.Max(currentA.Item1, currentB.Item1);
                    var secondPoint = Math.Min(currentA.Item2, currentB.Item2);
                    result.Add($"({firstPoint}, {secondPoint})");
                }

                if (currentA.Item2 > currentB.Item2)
                {
                    bIndex++;
                }
                else
                {
                    aIndex++;
                }
            }

            Console.WriteLine($"The interval inersection result of [(0, 2), (5, 10), (13, 23), (24, 25)] and [(1, 5), (8, 12), (15, 24), (25, 26)] is [{string.Join(", ", result)}]");
        }
    }
}

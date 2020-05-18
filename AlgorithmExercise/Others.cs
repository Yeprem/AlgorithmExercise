using System;

namespace AlgorithmExercise
{
    public class Others : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            FindPageCountNeedsToBeTurned(9, 5);
        }

        private void FindPageCountNeedsToBeTurned(int pageCount, int pageRequested)
        {
            /* To reach first page you don't need to turn a page */

            Console.Write($"How many pages needs to be turned to reach page {pageRequested} in a book with {pageCount} pages");

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

            Console.Write($"-> {result}");
        }
    }
}

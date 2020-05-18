using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise
{
    public class BitManupilations : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            FindNumberOfOnesInBinaryFormat();
        }

        /* O(log(x)) because it is proportional to the number of bits in a number */
        private void FindNumberOfOnesInBinaryFormat()
        {
            var queryValues = new List<int> { 2, 3, 5, 7 };

            foreach (var queryValue in queryValues)
            {
                Console.Write($"Number of ones in binary representation of number {queryValue} is ");

                var result = 0;
                var subject = queryValue;

                while (subject > 0)
                {
                    result += subject & 1;
                    subject >>= 1;
                }

                Console.WriteLine(result);
            }
        }
    }
}

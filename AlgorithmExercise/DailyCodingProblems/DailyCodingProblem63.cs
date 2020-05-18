using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise.DailyCodingProblems
{
    public class DailyCodingProblem63 : DailyCodingProblemBase<string>
    {
        protected override void RunIntrnal()
        {
            var set = new char[,]
            {
                { 'F', 'A', 'C', 'I' },
                { 'O', 'B', 'Q', 'P' },
                { 'A', 'N', 'O', 'B' },
                { 'M', 'A', 'S', 'S' }
            };

            var words = new List<string> { "FOAM", "MASS", "ACID", "NOB" };

            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];
                Console.WriteLine($"Can {word} be found in the set? -> {RunLogic(set, word)}");
            }
        }

        protected override string RunLogic(params object[] list)
        {
            var set = (char[,])list[0];
            var word = (string)list[1];

            var row = 0;
            var col = 0;
            var charIndex = 0;
            var found = false;
            var currentRow = 0;
            

            while (charIndex < word.Length)
            {
                var c = word[charIndex];

                if (set[row, col] == c)
                {
                    found = true;
                    row++;
                    charIndex++;
                }
                else
                {
                    row = currentRow;
                    col++;
                    charIndex = 0;
                    found = false;
                }

                if (col == set.GetLength(1) && !found)
                {
                    if (set.GetLength(0) - (currentRow + 1) < word.Length)
                    {                       
                        break;
                    }
                    else
                    {
                        currentRow++;
                        col = 0;
                    }
                }
            }

            if (!found)
            {
                col = 0;
                row = 0;
                charIndex = 0;
                var currentColumn = 0;

                while (charIndex < word.Length)
                {
                    var c = word[charIndex];

                    if (set[row, col] == c)
                    {
                        found = true;
                        col++;
                        charIndex++;
                    }
                    else
                    {
                        col = currentColumn;
                        row++;
                        charIndex = 0;
                        found = false;
                    }

                    if (row == set.GetLength(0) && !found)
                    {
                        if (set.GetLength(1) - (currentColumn + 1) < word.Length)
                        {
                            break;
                        }
                        else
                        {
                            currentColumn++;
                            row = 0;
                        }
                    }
                }
            }

            return found ? "YES" : "NO";
        }
    }
}

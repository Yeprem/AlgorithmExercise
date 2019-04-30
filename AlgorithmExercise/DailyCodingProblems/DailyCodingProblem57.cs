using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*        
        Given a string s and an integer k, break up the string into multiple texts such that each text has a length of k or less. You must break it up so that words don't break across lines. If there's no way to break the text up, then return null.

        You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.

        For example, given the string "the quick brown fox jumps over the lazy dog" and k = 10, you should return: ["the quick", "brown fox", "jumps over", "the lazy", "dog"]. No string in the list has a length of more than 10.         
    */
    
    public class DailyCodingProblem57 : DailyCodingProblemBase<List<string>>
    {
        protected override void RunIntrnal()
        {
            string set = "the quick brown fox jumps over the lazy dog";           
            int numOfChar = 10;
            Console.WriteLine($"Given the string {set} and # of chars = {numOfChar} break up the string is [{string.Join(", ", RunLogic(set, numOfChar))}]");
        }

        protected override List<string> RunLogic(params object[] list)
        {
            string set = (string)list[0];
            set += " "; // will use as a terminator
            int numOfChar = (int)list[1];
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder(numOfChar);
            int index = 0;
            string temp = string.Empty;
            int lastSpaceIndex = 0;

            while (index < set.Length)
            {
                if (set[index] == ' ')
                {
                    if (!string.IsNullOrWhiteSpace(temp))
                    {
                        sb.Append(temp);
                    }
                    temp = " ";
                    lastSpaceIndex = index;
                }
                else if (sb.Length + temp.Length <= numOfChar)
                {
                    temp += set[index];
                }
                else
                {
                    temp = string.Empty;
                    if (sb.Length > 0)
                    {
                        result.Add(sb.ToString());                        
                    }
                    else
                    {
                        break;
                    }
                    sb.Clear();
                    index = lastSpaceIndex;
                }

                index++;
            }

            if (sb.Length > 0)
            {
                result.Add(sb.ToString());
            }

            return result;
        }
    }
}

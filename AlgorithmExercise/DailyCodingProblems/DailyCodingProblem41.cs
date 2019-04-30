using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*
        Given an unordered list of flights taken by someone, each represented as (origin, destination) pairs, and a starting airport, compute the person's itinerary. If no such itinerary exists, return null. If there are multiple possible itineraries, return the lexicographically smallest one. All flights must be used in the itinerary.

        For example, given the list of flights [('SFO', 'HKO'), ('YYZ', 'SFO'), ('YUL', 'YYZ'), ('HKO', 'ORD')] and starting airport 'YUL', you should return the list ['YUL', 'YYZ', 'SFO', 'HKO', 'ORD'].

        Given the list of flights [('SFO', 'COM'), ('COM', 'YYZ')] and starting airport 'COM', you should return null.

        Given the list of flights [('A', 'B'), ('A', 'C'), ('B', 'C'), ('C', 'A')] and starting airport 'A', you should return the list ['A', 'B', 'C', 'A', 'C'] even though ['A', 'C', 'A', 'B', 'C'] is also a valid itinerary. However, the first one is lexicographically smaller. 
    */

    public class DailyCodingProblem41 : DailyCodingProblemBase<string>
    {
        protected override void RunIntrnal()
        {
            string startingPoint = "YUL";
            Dictionary<string, string> flights = new Dictionary<string, string>();
            flights.Add("SFO", "HKO");
            flights.Add("YYZ", "SFO");
            flights.Add("YUL", "YYZ");
            flights.Add("HKO", "ORD");
            Console.WriteLine($"Given the list of flights [{string.Join(", ", flights)}] with starting point {startingPoint} the itinerary is {RunLogic(flights, startingPoint)}");
        }

        protected override string RunLogic(params object[] list)
        {
            Dictionary<string, string> flights = (Dictionary<string, string>)list[0];
            string startingPoint = (string)list[1];
            List<string> itinerary = new List<string> { startingPoint };

            string current = startingPoint;

            while (current != null)
            {
                if (flights.TryGetValue(current, out string value))
                {
                    itinerary.Add(value);
                    current = value;
                }
                else
                {
                    current = null;
                }
            }

            return string.Join(", ", itinerary);
        }
    }
}

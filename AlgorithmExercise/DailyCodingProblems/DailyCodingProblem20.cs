using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*    
        Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.

        For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.

        In this example, assume nodes with the same value are the exact same node objects.

        Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
    */

    public class DailyCodingProblem20 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            var nodeCommon2 = new Node { Data = 10 };
            var nodeCommon1 = new Node { Data = 8, Next = nodeCommon2 };

            var nodeA2 = new Node { Data = 7, Next = nodeCommon1 };
            var nodeA1 = new Node { Data = 3, Next = nodeA2 };

            var nodeB2 = new Node { Data = 1, Next = nodeCommon1 };
            var nodeB1 = new Node { Data = 99, Next = nodeB2 };

            Console.WriteLine($"Intersection Point of {LinkedListRepresentation(nodeA1)} & {LinkedListRepresentation(nodeB1)} is {RunLogic(nodeA1, nodeB1)}");

            string LinkedListRepresentation(Node linkedList)
            {
                var sb = new StringBuilder();
                sb.Append(linkedList.Data);
                var iterator = linkedList.Next;
                while (iterator != null)
                {
                    sb.Append($"->{iterator.Data}");
                    iterator = iterator.Next;
                }

                return sb.ToString();
            }
        }

        protected override int RunLogic(params object[] list)
        {
            int result = 0;
            HashSet<int> hashset = new HashSet<int>();
            Node linkedList1 = (Node)list[0];
            Node linkedList2 = (Node)list[1];

            var iterator1 = linkedList1;
            while (iterator1 != null)
            {
                hashset.Add(iterator1.Data);
                iterator1 = iterator1.Next;
            }

            var iterator2 = linkedList2;
            while (iterator2 != null)
            {
                if (hashset.Contains(iterator2.Data))
                {
                    result = iterator2.Data;
                    break;
                }
                else
                {
                    iterator2 = iterator2.Next;
                }
            }

            return result;
        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
}

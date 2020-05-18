using System;
using System.Collections.Generic;

namespace AlgorithmExercise
{
    public class LinkedLists : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            PrintListInOrder();
            NthToLastLinkedListElement();
        }

        private void PrintListInOrder()
        {
            Console.WriteLine("Print the values in below tree in order");
            Console.WriteLine("1 - 2 - 3 - 8 - 9 - 11");
            Console.WriteLine("        |       |     ");
            Console.WriteLine("        4       10    ");
            Console.WriteLine("        |             ");
            Console.WriteLine("    6 - 5             ");
            Console.WriteLine("        |             ");
            Console.WriteLine("        7             ");


            var node11 = new TreeNode { Value = 11 };
            var node10 = new TreeNode { Value = 10 };
            var node9 = new TreeNode { Value = 9, Bottom = node10, Next = node11 };
            var node8 = new TreeNode { Value = 8, Next = node9 };
            var node7 = new TreeNode { Value = 7 };
            var node6 = new TreeNode { Value = 6 };
            var node5 = new TreeNode { Value = 5, Bottom = node6, Next = node7 };
            var node4 = new TreeNode { Value = 4, Next = node5 };
            var node3 = new TreeNode { Value = 3, Bottom = node4, Next = node8 };
            var node2 = new TreeNode { Value = 2, Next = node3 };
            var node1 = new TreeNode { Value = 1, Next = node2 };

            var stack = new Stack<TreeNode>();
            var node = node1;

            while (node != null)
            {
                Console.Write($"{node.Value} ");

                if (node.Bottom != null)
                {
                    stack.Push(node.Next);
                    node = node.Bottom;
                }
                else if (node.Next != null)
                {
                    node = node.Next;
                }
                else if (stack.Count > 0)
                {
                    node = stack.Pop();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
        }

        private void NthToLastLinkedListElement()
        {
            var queryValues = new List<int> { 1, 2, 3, 5 };
            var node5 = new ListNode { Value = 5 };
            var node4 = new ListNode { Value = 4, Next = node5 };
            var node3 = new ListNode { Value = 3, Next = node4 };
            var node2 = new ListNode { Value = 2, Next = node3 };
            var node = new ListNode { Value = 1, Next = node2 };

            foreach (var queryValue in queryValues)
            {
                Console.Write($"Given a singly linked list [1 -> 2 -> 3 -> 4 -> 5], what is the {queryValue}th item");

                var actualPointer = node;
                var secondaryPointer = node;

                for (int i = 0; i < queryValue; i++)
                {
                    if (secondaryPointer != null)
                    {
                        secondaryPointer = secondaryPointer.Next;
                    }
                }

                while (secondaryPointer?.Next != null)
                {
                    actualPointer = actualPointer.Next;
                    secondaryPointer = secondaryPointer.Next;
                }

                var result = secondaryPointer != null ? actualPointer.Value : -1;
                Console.WriteLine($" -> { result }");
            }
        }
    }

    class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }
    }

    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Next { get; set; }
        public TreeNode Bottom { get; set; }
    }
}

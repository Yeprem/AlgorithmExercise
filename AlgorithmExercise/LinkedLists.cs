using System;
using System.Collections.Generic;

namespace AlgorithmExercise
{
    public class LinkedLists : AlgorithmBase
    {

        /*
            
            To create a stack with push pop and max functions which runs in O(1), 
            use linked list with max value as a field in node. 
             
        */

        protected override void RunIntrnal()
        {
            PrintListInOrder();
            NthToLastLinkedListElement();
            FindCycle();
            IsLinkdListPalindrome();
            ReverseLinkedList();
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

        private void FindCycle()
        {
            var node5WithCycle = new ListNode { Value = 5 };
            var node4WithCycle = new ListNode { Value = 4, Next = node5WithCycle };
            var node3WithCycle = new ListNode { Value = 3, Next = node4WithCycle };
            var node2WithCycle = new ListNode { Value = 2, Next = node3WithCycle };
            var nodeWithCycle = new ListNode { Value = 1, Next = node2WithCycle };
            node5WithCycle.Next = node3WithCycle;

            var node5 = new ListNode { Value = 5 };
            var node4 = new ListNode { Value = 4, Next = node5 };
            var node3 = new ListNode { Value = 3, Next = node4 };
            var node2 = new ListNode { Value = 2, Next = node3 };
            var node = new ListNode { Value = 1, Next = node2 };

            var queryValues = new List<(string, ListNode)>
            {
                ("1 -> 2 -> 3 -> 4 -> 5", node),
                ("1 -> 2 -> 3 -> 4 -> 5 -> 3", nodeWithCycle)
            };

            foreach (var queryValue in queryValues)
            {
                var result = false;
                var slowP = queryValue.Item2;
                var fastP = queryValue.Item2?.Next?.Next;

                while (fastP?.Next != null)
                {
                    slowP = slowP.Next;
                    fastP = fastP.Next.Next;

                    if (slowP.Value == fastP.Value)
                    {
                        result = true;
                        break;
                    }
                }                

                Console.WriteLine($"Is LinkedList [{queryValue.Item1}] contains cycle? -> {result}");
            }
        }
        
        private void IsLinkdListPalindrome()
        {
            var node5Palindrome = new ListNode { Value = 1 };
            var node4Palindrome = new ListNode { Value = 2, Next = node5Palindrome };
            var node3Palindrome = new ListNode { Value = 3, Next = node4Palindrome };
            var node2Palindrome = new ListNode { Value = 2, Next = node3Palindrome };
            var nodePalindrome = new ListNode { Value = 1, Next = node2Palindrome };

            var node5 = new ListNode { Value = 5 };
            var node4 = new ListNode { Value = 4, Next = node5 };
            var node3 = new ListNode { Value = 3, Next = node4 };
            var node2 = new ListNode { Value = 2, Next = node3 };
            var node = new ListNode { Value = 1, Next = node2 };

            var queryValues = new List<(string, ListNode)>
            {
                ("1 -> 2 -> 3 -> 4 -> 5", node),
                ("1 -> 2 -> 3 -> 2 -> 1", nodePalindrome)
            };

            foreach (var queryValue in queryValues)
            {
                var result = true;

                var currentNode = queryValue.Item2;
                var stack = new Stack<int>();
                while (currentNode != null)
                {
                    stack.Push(currentNode.Value);
                    currentNode = currentNode.Next;
                }

                currentNode = queryValue.Item2;
                while (stack.Count > 0)
                {
                    var currentValue = stack.Pop();
                    if (currentNode.Value != currentValue)
                    {
                        result = false;
                        break;
                    }

                    currentNode = currentNode.Next;
                }

                Console.WriteLine($"Is LinkedList [{queryValue.Item1}] palindrome? -> {result}");
            }
        }

        private void ReverseLinkedList()
        {
            var node5 = new ListNode { Value = 5 };
            var node4 = new ListNode { Value = 4, Next = node5 };
            var node3 = new ListNode { Value = 3, Next = node4 };
            var node2 = new ListNode { Value = 2, Next = node3 };
            var node = new ListNode { Value = 1, Next = node2 };

            var result = new List<int>();

            var current = node.Next;
            var previous = node;
            node.Next = null;

            while (current?.Next != null)
            {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }

            current.Next = previous;

            var iterator = node5;
            while (iterator != null)
            {
                result.Add(iterator.Value);
                iterator = iterator.Next;
            }

            Console.WriteLine($"Reversed version of he linked list [1 -> 2 -> 3 -> 4 -> 5] is [{string.Join(" -> ", result)}]");

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

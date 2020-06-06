using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercise
{
    public class Trees : AlgorithmBase
    {
        protected override void RunIntrnal()
        {
            var node7 = new TreeNode { Value = 7 };
            var node6 = new TreeNode { Value = 6 };
            var node5 = new TreeNode { Value = 5 };
            var node4 = new TreeNode { Value = 4 };
            var node3 = new TreeNode { Value = 3, Left = node6, Right = node7 };
            var node2 = new TreeNode { Value = 2, Left = node4, Right = node5 };
            var root = new TreeNode { Value = 1, Left = node2, Right = node3 };

            BFS(root);
            ZigZagTraversal(root);
            SumOfPathNumbers(root);

        }

        private void BFS(TreeNode root)
        {
            /* BFS - level order traversal */

            var result = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.Value);
                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            Console.WriteLine("Level order traversal of the Tree");
            Console.WriteLine("     1      ");
            Console.WriteLine("   /   \\    ");
            Console.WriteLine("  2     3   ");
            Console.WriteLine(" / \\   / \\");
            Console.WriteLine("4   5 6   7");
            Console.WriteLine($"is {string.Join(", ", result)}");
        }

        private void ZigZagTraversal(TreeNode root)
        {
            var result = new List<int>();
            var primaryStack = new Stack<TreeNode>();
            var secondaryStack = new Stack<TreeNode>();
            primaryStack.Push(root);
            var leftToRight = true;

            while (primaryStack.Count > 0 || secondaryStack.Count > 0)
            {
                var currentStack = leftToRight ? primaryStack : secondaryStack;
                var stageStack = !leftToRight ? primaryStack : secondaryStack;

                var current = currentStack.Pop();
                result.Add(current.Value);

                if (leftToRight)
                {
                    if (current.Left != null)
                    {
                        stageStack.Push(current.Left);
                    }

                    if (current.Right != null)
                    {
                        stageStack.Push(current.Right);
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        stageStack.Push(current.Right);
                    }

                    if (current.Left != null)
                    {
                        stageStack.Push(current.Left);
                    }
                }

                if (currentStack.Count == 0)
                {
                    leftToRight = !leftToRight;
                }
            }

            Console.WriteLine("ZigZag traversal of the Tree");
            Console.WriteLine("     1      ");
            Console.WriteLine("   /   \\    ");
            Console.WriteLine("  2     3   ");
            Console.WriteLine(" / \\   / \\");
            Console.WriteLine("4   5 6   7");
            Console.WriteLine($"is {string.Join(", ", result)}");
        }

        private void SumOfPathNumbers(TreeNode root)
        {
            /* DFS - Preorder */
            var result = new List<int>();
            var sum = 0;

            Traverse(root, string.Empty);

            void Traverse(TreeNode node, string value)
            {
                if (node.Left == null && node.Right == null)
                {
                    var intValue = int.Parse($"{value}{node.Value}");
                    sum += intValue;
                    result.Add(intValue);
                }

                if (node.Left != null)
                {
                    Traverse(node.Left, $"{value}{node.Value}");
                }

                if (node.Right != null)
                {
                    Traverse(node.Right, $"{value}{node.Value}");
                }             
            }

            Console.WriteLine("Sum of Path Numbers from Tree");
            Console.WriteLine("     1      ");
            Console.WriteLine("   /   \\    ");
            Console.WriteLine("  2     3   ");
            Console.WriteLine(" / \\   / \\");
            Console.WriteLine("4   5 6   7");
            Console.WriteLine($"is {string.Join(" + ", result)} = {sum}");
        }

        class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode Left { get; set; }
        }
    }

}

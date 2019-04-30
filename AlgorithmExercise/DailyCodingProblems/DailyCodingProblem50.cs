using System;
using System.Collections.Generic;

namespace AlgorithmExercise.DailyCodingProblems
{
    /*    
        Suppose an arithmetic expression is given as a binary tree. Each leaf is an integer and each internal node is one of '+', '−', '∗', or '/'.

        Given the root to such a tree, write a function to evaluate it.

        For example, given the following tree:

            *
           / \
          +    +
         / \  / \
        3  2  4  5

        You should return 45, as it is (3 + 2) * (4 + 5).         
    */


    public class DailyCodingProblem50 : DailyCodingProblemBase<int>
    {
        protected override void RunIntrnal()
        {
            TreeNode node7 = new TreeNode { Data = "5" };
            TreeNode node6 = new TreeNode { Data = "4" };
            TreeNode node5 = new TreeNode { Data = "2" };
            TreeNode node4 = new TreeNode { Data = "3" };
            TreeNode node3 = new TreeNode { Data = "+", Left = node6, Right = node7 };
            TreeNode node2 = new TreeNode { Data = "+", Left = node4, Right = node5 };
            TreeNode root = new TreeNode { Data = "*", Left = node2, Right = node3 };

            Console.WriteLine($"Given the root to a tree, the result is {RunLogic(root)}");
        }

        protected override int RunLogic(params object[] list)
        {
            TreeNode root = (TreeNode)list[0];
            Stack<int> stack = new Stack<int>();

            Evaluate(root);

            return stack.Count > 0 
                ? stack.Pop()
                : 0;

            void Evaluate(TreeNode node)
            {
                // PostOrder traversal used here

                if (node.Left != null)
                {
                    Evaluate(node.Left);
                }

                if (node.Right != null)
                {
                    Evaluate(node.Right);
                }

                if (int.TryParse(node.Data, out int value))
                {
                    stack.Push(value);
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();

                    if (node.Data == "+")
                    {
                        stack.Push(a + b);
                    }
                    else if (node.Data == "-")
                    {
                        stack.Push(a - b);
                    }
                    else if (node.Data == "*")
                    {
                        stack.Push(a * b);
                    }
                    else
                    {
                        stack.Push(a / b);
                    }
                }
            }
        }

        class TreeNode
        {
            public string Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
    }
}

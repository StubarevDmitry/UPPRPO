using BRTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPRPO_Lab1_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RedBlackTree tree = new RedBlackTree();

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(5);

            Console.WriteLine("Inorder Traversal of Created Tree:");
            tree.PrintTree();
            Console.ReadKey();
        }
    }
}

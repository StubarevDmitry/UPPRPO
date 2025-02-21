using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRTree
{
    using System;

    public enum Color
    {
        Red,
        Black
    }

    public class Node
    {
        public int Data { get; set; }
        public Color Color { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public Node(int data)
        {
            Data = data;
            Color = Color.Red; // Новые узлы всегда красные
            Left = Right = Parent = null;
        }
    }

    public class RedBlackTree
    {
        private Node root;

        // Возвращает корень дерева (для тестирования)
        public Node GetRoot()
        {
            return root;
        }

        // Поиск элемента в дереве
        public Node Search(int data)
        {
            return Search(root, data);
        }

        private Node Search(Node node, int data)
        {
            if (node == null || node.Data == data)
                return node;

            if (data < node.Data)
                return Search(node.Left, data);

            return Search(node.Right, data);
        }

        // Подсчет количества элементов в дереве
        public int Count()
        {
            return Count(root);
        }

        private int Count(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Count(node.Left) + Count(node.Right);
        }


        // Вспомогательный метод для поворота влево
        private void RotateLeft(Node node)
        {
            Node rightChild = node.Right;
            node.Right = rightChild.Left;

            if (rightChild.Left != null)
                rightChild.Left.Parent = node;

            rightChild.Parent = node.Parent;

            if (node.Parent == null)
                root = rightChild;
            else if (node == node.Parent.Left)
                node.Parent.Left = rightChild;
            else
                node.Parent.Right = rightChild;

            rightChild.Left = node;
            node.Parent = rightChild;
        }

        // Вспомогательный метод для поворота вправо
        private void RotateRight(Node node)
        {
            Node leftChild = node.Left;
            node.Left = leftChild.Right;

            if (leftChild.Right != null)
                leftChild.Right.Parent = node;

            leftChild.Parent = node.Parent;

            if (node.Parent == null)
                root = leftChild;
            else if (node == node.Parent.Right)
                node.Parent.Right = leftChild;
            else
                node.Parent.Left = leftChild;

            leftChild.Right = node;
            node.Parent = leftChild;
        }

        // Вспомогательный метод для исправления нарушений после вставки
        private void FixInsert(Node node)
        {
            while (node != root && node.Parent.Color == Color.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    Node uncle = node.Parent.Parent.Right;

                    if (uncle != null && uncle.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        uncle.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    Node uncle = node.Parent.Parent.Left;

                    if (uncle != null && uncle.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        uncle.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            root.Color = Color.Black;
        }

        // Вставка нового узла
        public void Insert(int data)
        {
            Node newNode = new Node(data);

            if (root == null)
            {
                root = newNode;
                root.Color = Color.Black;
                return;
            }

            Node current = root;
            Node parent = null;

            while (current != null)
            {
                parent = current;
                if (newNode.Data < current.Data)
                    current = current.Left;
                else
                    current = current.Right;
            }

            newNode.Parent = parent;

            if (newNode.Data < parent.Data)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            FixInsert(newNode);
        }

        // Вспомогательный метод для вывода дерева (inorder traversal)
        private void InOrderTraversal(Node node)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InOrderTraversal(node.Right);
        }

        // Публичный метод для вывода дерева
        public void PrintTree()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }
    }
}

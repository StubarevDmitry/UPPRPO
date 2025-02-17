using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    using BRTree;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void Insert_SingleElement_ShouldSetRoot()
        {
            // Arrange
            var tree = new RedBlackTree();

            // Act
            tree.Insert(10);

            // Assert
            // Проверяем, что корень дерева существует и содержит правильное значение
            Assert.IsNotNull(tree.GetRoot());
            Assert.AreEqual(10, tree.GetRoot().Data);
            Assert.AreEqual(Color.Black, tree.GetRoot().Color);
        }

        [TestMethod]
        public void Insert_MultipleElements_ShouldMaintainRedBlackProperties()
        {
            // Arrange
            var tree = new RedBlackTree();

            // Act
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(5);

            // Assert
            // Проверяем, что дерево содержит все вставленные элементы
            Assert.IsNotNull(tree.Search(10));
            Assert.IsNotNull(tree.Search(20));
            Assert.IsNotNull(tree.Search(30));
            Assert.IsNotNull(tree.Search(15));
            Assert.IsNotNull(tree.Search(25));
            Assert.IsNotNull(tree.Search(5));

            // Проверяем, что корень дерева черный (свойство красно-черного дерева)
            Assert.AreEqual(Color.Black, tree.GetRoot().Color);
        }

        [TestMethod]
        public void Search_NonExistentElement_ShouldReturnNull()
        {
            // Arrange
            var tree = new RedBlackTree();
            tree.Insert(10);

            // Act
            var result = tree.Search(20); // Поиск несуществующего элемента

            // Assert
            Assert.IsNull(result);
        }
    }
}

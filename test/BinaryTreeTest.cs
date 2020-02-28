using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollection.Heap;
using MyCollection.Tree;

namespace test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void LevelOrderTraverssal()
		{
			var set = CreateTree();

			var setOut = set.LevelOrderTraverssal()
				.ToList();

			Assert.AreEqual(1, setOut[0].Value);
			Assert.AreEqual(2, setOut[1].Value);
			Assert.AreEqual(3, setOut[2].Value);
			Assert.AreEqual(4, setOut[3].Value);
			Assert.AreEqual(5, setOut[4].Value);
			Assert.AreEqual(6, setOut[5].Value);
		}

		[TestMethod]
		public void LevelOrderTraverssalLevel1()
		{
			var set = CreateTree();

			var setOut = set.LevelOrderTraverssal(1)
				.ToList();

			Assert.AreEqual(1, setOut[0].Value);
		}

		[TestMethod]
		public void LevelOrderTraverssalLevel2()
		{
			var set = CreateTree();

			var setOut = set.LevelOrderTraverssal(2)
				.ToList();

			Assert.AreEqual(2, setOut[0].Value);
			Assert.AreEqual(3, setOut[1].Value);
		}

		[TestMethod]
		public void LevelOrderTraverssalLevel3()
		{
			var set = CreateTree();

			var setOut = set.LevelOrderTraverssal(3)
				.ToList();

			Assert.AreEqual(4, setOut[0].Value);
			Assert.AreEqual(5, setOut[1].Value);
			Assert.AreEqual(6, setOut[2].Value);
		}

		[TestMethod]
		public void PostOrderTraverssal()
		{
			var set = CreateTree();

			var setOut = set.PostOrderTraverssal()
				.ToList();

			Assert.AreEqual(4, setOut[0].Value);
			Assert.AreEqual(5, setOut[1].Value);
			Assert.AreEqual(2, setOut[2].Value);
			Assert.AreEqual(6, setOut[3].Value);
			Assert.AreEqual(3, setOut[4].Value);
			Assert.AreEqual(1, setOut[5].Value);
		}

		[TestMethod]
		public void PreOrderTraverssal()
		{
			var set = CreateTree();

			var setOut = set.PreOrderTraverssal()
				.ToList();

			Assert.AreEqual(1, setOut[0].Value);
			Assert.AreEqual(2, setOut[1].Value);
			Assert.AreEqual(4, setOut[2].Value);
			Assert.AreEqual(5, setOut[3].Value);
			Assert.AreEqual(3, setOut[4].Value);
			Assert.AreEqual(6, setOut[5].Value);
		}

		[TestMethod]
		public void InOrderTraverssal()
		{
			var set = CreateTree();

			var setOut = set.InOrderTraverssal()
				.ToList();

			Assert.AreEqual(4, setOut[0].Value);
			Assert.AreEqual(2, setOut[1].Value);
			Assert.AreEqual(5, setOut[2].Value);
			Assert.AreEqual(1, setOut[3].Value);
			Assert.AreEqual(6, setOut[4].Value);
			Assert.AreEqual(3, setOut[5].Value);
		}

		private static BinaryTree<int> CreateTree()
		{
			var set = new BinaryTree<int>();

			set.Root = new BinaryTreeNode<int>
			{
				Value = 1,
				Left = new BinaryTreeNode<int>
				{
					Value = 2,
					Left = new BinaryTreeNode<int>
					{
						Value = 4
					},
					Right = new BinaryTreeNode<int>
					{
						Value = 5
					}
				},
				Right = new BinaryTreeNode<int>
				{
					Value = 3,
					Left = new BinaryTreeNode<int>
					{
						Value = 6
					},
				}
			};
			return set;
		}

		//private static BinaryTree<int> CreateBigTree()
		//{
		//	var set = CreateTree();

		//	set.Root.Left

		//	return set;
		//}

	}
}

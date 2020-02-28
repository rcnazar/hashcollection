using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCollection.Tree
{

    public class BinaryTree<T>
        where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; set; }


		public IEnumerable<BinaryTreeNode<T>> LevelOrderTraverssal(int? level = null)
		{
			var set = new Queue<BinaryTreeNode<T>>();
			var currLevel = 0;
			int count = 0;
			set.Enqueue(Root);

			while (set.Any())
			{
				if (count == 0)
				{
					count = set.Count;
					currLevel++;
				}

				var currentNode = set.Dequeue();

				if (!level.HasValue || level == currLevel)
				{
					yield return currentNode;
				}

				currentNode.Children()
					.ToList()
					.ForEach(set.Enqueue);

				count--;
			}
		}

		public IEnumerable<BinaryTreeNode<T>> PreOrderTraverssal()
		{
			var set = new Stack<BinaryTreeNode<T>>();
			set.Push(Root);

			while (set.Any())
			{
				var curr = set.Pop();
				yield return curr;

				curr.Children()
					.Reverse()
					.ToList()
					.ForEach(set.Push);
			}
		}

		public IEnumerable<BinaryTreeNode<T>> InOrderTraverssal()
		{
			var set = new Stack<BinaryTreeNode<T>>();
			BinaryTreeNode<T> curr = Root;

			while (curr != null || set.Any())
			{
				while (curr != null)
				{
					set.Push(curr);
					curr = curr.Left;
				}

				curr = set.Pop();
				yield return curr;

				curr = curr.Right;
			}
		}

		public IEnumerable<BinaryTreeNode<T>> PostOrderTraverssal()
		{
			var set = new Stack<BinaryTreeNode<T>>();
			set.Push(Root);
			BinaryTreeNode<T> prev = null;

			while (set.Any())
			{
				var curr = set.Peek();

				var backing = prev != null && (prev == curr.Left || prev == curr.Right);
				var backingFromRight = prev != null && prev == curr.Right;

				if (!backing && curr.Left != null)
				{
					set.Push(curr.Left);
				}
				else if (!backingFromRight && curr.Right != null)
				{
					set.Push(curr.Right);
				}
				else
				{
					set.Pop();
					yield return curr;
				}

				prev = curr;
			}
		}

	}

}
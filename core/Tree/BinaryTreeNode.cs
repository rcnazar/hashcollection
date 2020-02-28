using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCollection.Tree
{

    public class BinaryTreeNode<T>
        where T: IComparable
    {

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; set; }

        public IEnumerable<BinaryTreeNode<T>> Children()
        {
			if (Left != null)
			{
				yield return Left;
			}

			if (Right != null)
			{
				yield return Right;
			}
        }

        public bool IsLesserThan(BinaryTreeNode<T> node)
        {
            return this.Value.CompareTo(node.Value) < 0;
        }

        public bool IsLesserOrEqualsTo(BinaryTreeNode<T> node)
        {
            return this.Value.CompareTo(node.Value) <= 0;
        }

        public bool IsGreaterThan(BinaryTreeNode<T> node)
        {
            return this.Value.CompareTo(node.Value) > 0;
        }

        public bool IsGreaterOrEqualsTo(BinaryTreeNode<T> node)
        {
            return this.Value.CompareTo(node.Value) >= 0;
        }

    }

}
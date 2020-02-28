using System;
using System.Linq;
using MyCollection.Tree;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyCollection.Heap
{

    public class Heap<T>
        where T: IComparable
    {

        private T[] _set;
        private int _size = 0;
		private IComparer<T> _comparer;
		private bool _reversed = false;

		public Heap(int capacity = 10) : this(ListSortDirection.Ascending, capacity)
		{

		}

		public Heap(ListSortDirection direction, int capacity = 10)
		{
            _set = new T[capacity];
			_comparer = Comparer<T>.Default;
			_reversed = direction == ListSortDirection.Descending;
		}

		public Heap(IComparer<T> comparer, int capacity = 10)
        {
            _set = new T[capacity];
			_comparer = comparer ?? Comparer<T>.Default;
		}

        public void Add(T value)
        {
            if (_size >= _set.Length)
            {
                Grow();
            }

			_set[_size] = value;

            _size++;

			HeapifyBotton();
		}

		public T Get()
		{
			return _set[0];
		}

        public T Extract()
		{
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var retorno = _set[0];

            HeapifyTop();
            _size--;

			return retorno;
		}

        private void HeapifyTop()
        {
            if (_size < 2)
            {
                return;
            }

            _set[0] = _set[_size - 1];
            _set[_size - 1] = default(T);

            var index = 0;

            while (index < _size)
            {
                var leftIndex = GetLeftIndex(index);
                var rightIndex = GetRightIndex(index);

                if (NeedSwitch(rightIndex, leftIndex) && NeedSwitch(leftIndex, index))
                {
                    Swap(0, leftIndex.Value);
                    index = leftIndex.Value;
                }
                else if (NeedSwitch(rightIndex, index))
                {
                    Swap(0, rightIndex.Value);
                    index = rightIndex.Value;
                }
                else
                {
                    break;
                }
            }
        }

		private void HeapifyBotton()
		{
			var index = _size - 1;

			while (index != 0)
			{
				var parentIndex = GetParentIndex(index);

				if (NeedSwitch(index, parentIndex))
				{
					break;
				}

				Swap(index, parentIndex);
				index = parentIndex;
			}
		}

        private bool NeedSwitch(int? index, int? parentIndex)
        {
            if (index == null || parentIndex == null)
            {
                return false;
            }

            return ((_reversed && _comparer.Compare(_set[index.Value], _set[parentIndex.Value]) <= 0) ||
					(!_reversed && _comparer.Compare(_set[index.Value], _set[parentIndex.Value]) >= 0));
        }

        private void Grow()
        {
            var newSize = (int)Math.Floor(_size * 1.2);
			Array.Resize(ref _set, newSize);
        }

		private int GetParentIndex(int index)
		{
			return (index - 1) / 2;
		}

		private int? GetLeftIndex(int index)
		{
            var retorno = index * 2 + 1;
			return retorno < _size ? retorno : (int?)null;
		}

		private int? GetRightIndex(int index)
		{
            var retorno = index * 2 + 2;
			return retorno < _size ? retorno : (int?)null;
		}

		private void Swap(int n1, int n2)
		{
			var temp = _set[n1];
			_set[n1] = _set[n2];
			_set[n2] = temp;
		}



	}

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HashCollection
{

    public class MyHashTable<T> : IEnumerable<T>, ICollection<T>
	{
        private List<ValueHash<T>>[] _arr;
        private int _count = 0;
        private decimal _fill;
		public int Count => _count;
		public bool IsReadOnly => false;

		public MyHashTable(int size = 16, decimal fill = 0.75m)
        {
            _arr = new List<ValueHash<T>>[size];
            _fill = fill;
        }

        public void Add(T value)
        {
            if (AddValueHash(new ValueHash<T>(value)))
			{
				_count++;
			}

			Rehash();
		}

		private bool AddValueHash(ValueHash<T> valueHash)
        {
            var index = GetIndex(valueHash);

            if (_arr[index] == null)
            {
                _arr[index] = new List<ValueHash<T>>();
            }

            if (CheckList(_arr[index], valueHash))
            {
				return false;
            }

            _arr[index].Add(valueHash);
			return true;
        }

        public bool Contains(T value)
        {
            var valueHash = new ValueHash<T>(value);
            var index = GetIndex(valueHash);

            return _arr[index] != null && CheckList(_arr[index], valueHash);
        }

        public bool Remove(T value)
        {
            var valueHash = new ValueHash<T>(value);
            var index = GetIndex(valueHash);

            if (_arr[index] == null || !CheckList(_arr[index], valueHash))
            {
				return false;
            }

            _arr[index].Remove(valueHash);
			_count--;
			return true;
		}

        private int GetIndex(ValueHash<T> value)
        {
            return value.Hashcode % _arr.Length;
        }

        private bool CheckList(List<ValueHash<T>> list, ValueHash<T> valueHash)
        {
            if (list.Count == 0)
            {
                return false;
            }

            return list.Any(a => a.Hashcode == valueHash.Hashcode);
        }

        private void Rehash()
        {
            if (_count/_arr.Length < _fill)
            {
                return;
            }

            Console.WriteLine($"Rehashing: {_arr.Length} -> {_arr.Length * 2}");

            var _arrOld = _arr;
            _arr = new List<ValueHash<T>>[_arr.Length * 2];

            foreach (var itemArr in _arrOld)
            {
                if (itemArr == null)
                {
                    continue;
                }

                foreach (var item in itemArr)
                {
                    AddValueHash(item);
                }
            }
        }

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		public void Clear()
		{
			Array.Clear(_arr, 0, _arr.Length);
			_count--;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			foreach (var item in this)
			{
				array[arrayIndex] = item;
				arrayIndex++;
			}
		}

		public struct Enumerator : IEnumerator<T>, IEnumerator
		{
			private MyHashTable<T> _hashSet;
			private int _index;
			private int _indexSub;
			private T _current;

			public object Current => _current;

			T IEnumerator<T>.Current => _current;

			internal Enumerator(MyHashTable<T> hashSet)
			{
				_hashSet = hashSet;
				_index = 0;
				_indexSub = 0;
				_current = default;
			}

			public bool MoveNext()
			{
				while (true)
				{
					if (_hashSet._arr[_index] == null || ++_indexSub >= _hashSet._arr[_index].Count)
					{
						_index++;
						_indexSub = 0;
					}

					if (_index < _hashSet._arr.Length)
					{
						return false;
					}

					if (_hashSet._arr[_index] != null)
					{
						_current = _hashSet._arr[_index][_indexSub].Value;
						return true;
					}
				}
			}

			public void Reset()
			{
				_index = 0;
				_indexSub = 0;
				_current = default;
			}

			public void Dispose()
			{
			}
		}


	}

}
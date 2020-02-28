using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyCollection.Hash
{

	public class MyHashTable<K, V> //: IEnumerable<Entry<K, V>>, ICollection<Entry<K, V>>
	{
		private List<Entry<K, V>>[] _arr;
		private decimal _fill;
		public int Count { get; private set; } = 0;
		public bool IsReadOnly => false;

		public V this[K key]
		{
			get
			{
				return Get(key);
			}
			set
			{
				Set(key, value);
			}
		}

		public MyHashTable(int size = 16, decimal fill = 0.75m)
		{
			_arr = new List<Entry<K, V>>[size];
			_fill = fill;
		}

		public bool Add(K key, V value)
		{
			var entry = new Entry<K, V>(key, value);
			var index = entry.GetIndex(_arr.Length);
			var list = _arr[index];
			var entry_internal = GetEntry(list, entry.Key);

			if (entry_internal != null)
			{
				return false;
			}

			AddEntry(entry, index, list);

			return true;
		}

		public void Set(K key, V value)
		{
			var entry = GetEntry(key);

			if (entry != null)
			{
				var index = entry.Value.GetIndex(_arr.Length);
				var list = _arr[index];
				list[list.IndexOf(entry.Value)] = new Entry<K, V>(key, value);
			}
			else
			{
				Add(key, value);
			}
		}

		private void AddEntry(Entry<K, V> entry, int index)
		{
			var list = GetList(entry);

			AddEntry(entry, index, list);
		}

		private void AddEntry(Entry<K, V> entry, int index, List<Entry<K, V>> list)
		{
			if (list == null)
			{
				list = new List<Entry<K, V>>();
				_arr[index] = list;
			}

			list.Add(entry);
			Count++;
			Rehash();
		}

		public bool Contains(K key)
		{
			var entry = GetEntry(key);

			return entry != null;
		}

		public bool Remove(K key)
		{
			var list = GetList(key);
			var entry = GetEntry(list, key);

			if (entry == null)
			{
				return false;
			}

			list.Remove(entry.Value);
			Count--;
			return true;
		}

		public V Get(K key)
		{
			var entry = GetEntry(key);

			if (entry == null)
			{
				throw new KeyNotFoundException(key.ToString());
			}

			return entry.Value.Value;
		}

		private Entry<K, V>? GetEntry(Entry<K, V> entry)
		{
			var list = GetList(entry);

			return GetEntry(list, entry.Key);
		}

		private Entry<K, V>? GetEntry(K key)
		{
			var list = GetList(key);

			return GetEntry(list, key);
		}

		private Entry<K, V>? GetEntry(List<Entry<K, V>> list, K key)
		{
			if (list == null)
			{
				return null;
			}

			return list.FirstOrDefault(a => a.Key.Equals(key));
		}

		private List<Entry<K, V>> GetList(K key)
		{
			var entry = new Entry<K, V>(key, default(V));
			return GetList(entry);
		}

		private List<Entry<K, V>> GetList(Entry<K, V> entry)
		{
			var index = entry.GetIndex(_arr.Length);
			var list = _arr[index];
			return list;
		}

		private void Rehash()
		{
			if (Count / _arr.Length < _fill)
			{
				return;
			}

			Console.WriteLine($"Rehashing: {_arr.Length} -> {_arr.Length * 2}");

			var _arrOld = _arr;
			_arr = new List<Entry<K, V>>[_arr.Length * 2];
			Count = 0;

			foreach (var itemArr in _arrOld)
			{
				if (itemArr == null)
				{
					continue;
				}

				foreach (var item in itemArr)
				{
					AddEntry(item, item.GetIndex(_arr.Length));
				}
			}
		}

		//public IEnumerator<K> GetEnumerator()
		//{
		//	return new Enumerator(this);
		//}

		//IEnumerator IEnumerable.GetEnumerator()
		//{
		//	return new Enumerator(this);
		//}

		public void Clear()
		{
			Array.Clear(_arr, 0, _arr.Length);
			Count--;
		}

		//public void CopyTo(K[] array, int arrayIndex)
		//{
		//	foreach (var item in this)
		//	{
		//		array[arrayIndex] = item;
		//		arrayIndex++;
		//	}
		//}

		public struct Enumerator : IEnumerator<K>, IEnumerator
		{
			private MyHashTable<K, V> _hashSet;
			private int _index;
			private int _indexSub;
			private K _current;

			public object Current => _current;

			K IEnumerator<K>.Current => _current;

			internal Enumerator(MyHashTable<K, V> hashSet)
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
						//_current = _hashSet._arr[_index][_indexSub].Value;
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

	public struct Entry<K, V>
	{
		public K Key;
		public V Value;
		public int HashCode;

		public Entry(K key, V value)
		{
			Key = key;
			Value = value;
			HashCode = key.GetHashCode();
		}

		public override int GetHashCode()
		{
			return HashCode;
		}

		public int GetIndex(int size)
		{
			return (int)((uint)HashCode % size);
		}

		public override bool Equals(object obj)
		{
			if (Value == null || obj == null)
			{
				return Value == null && obj == null;
			}
			else if (obj is Entry<K, V>)
			{
				return Value.Equals(((Entry<K, V>)obj).Value);
			}
			else if (obj is V)
			{
				return Value.Equals(obj);
			}

			return false;
		}
	}

}
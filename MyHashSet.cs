using System;
using System.Collections.Generic;
using System.Linq;


namespace HashCollection
{

    public class MyHashSet<T>
    {
        private List<ValueHash<T>>[] _arr;

        private int _count = 0;
        private decimal _fill;

        public MyHashSet(int size = 16, decimal fill = 0.75m)
        {
            _arr = new List<ValueHash<T>>[size];
            _fill = fill;
        }

        public void Add(T value)
        {
            Console.WriteLine($"Add");
            _count++;
            Rehash();

            AddValueHash(new ValueHash<T>(value));
        }

        private void AddValueHash(ValueHash<T> valueHash)
        {
            var index = GetIndex(valueHash);

            if (_arr[index] == null)
            {
                _arr[index] = new List<ValueHash<T>>();
            }

            if (CheckList(_arr[index], valueHash))
            {
                throw new ArgumentException();
            }

            _arr[index].Add(valueHash);
        }

        public bool HasKey(T value)
        {
            var valueHash = new ValueHash<T>(value);
            var index = GetIndex(valueHash);

            return _arr[index] != null && CheckList(_arr[index], valueHash);
        }

        public void RemoveKey(T value)
        {
            Console.WriteLine($"Remove");
            var valueHash = new ValueHash<T>(value);
            var index = GetIndex(valueHash);

            if (_arr[index] == null || !CheckList(_arr[index], valueHash))
            {
                throw new ArgumentException();
            }

            Console.WriteLine(_arr.Length);
            _arr[index].Remove(valueHash);
            Console.WriteLine(_arr.Length);
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

    }

}
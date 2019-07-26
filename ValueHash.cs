using System;
using System.Collections.Generic;
using System.Linq;


namespace HashCollection
{

    public class ValueHash<T>
    {

        private T _value;
        private int _hashcode;

        public T Value
        {
            get {
                return _value;
            }
            set {
                _value = value;
                _hashcode = value.GetHashCode();
            }
        }

        public int Hashcode => _hashcode;

        public ValueHash()
        {

        }

        public ValueHash(T value)
        {
            Value = value;
        }

        public override int GetHashCode()
        {
            return _hashcode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ValueHash<T>))
            {
                return false;
            }

            return Value.Equals(((ValueHash<T>)obj).Value);
        }

    }

}
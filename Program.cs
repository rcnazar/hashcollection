using System;
using System.Collections.Generic;
using System.Linq;
using HashCollection;


namespace hashcollection
{

    class Obj
    {
        private string _valor;

        public Obj(string valor)
        {
            _valor = valor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var hash1 = new MyHashSet<int>();
            hash1.Add(1);

            Console.WriteLine(hash1.HasKey(1));
            Console.WriteLine(hash1.HasKey(2));
            Console.WriteLine(hash1.HasKey(3));

            Console.WriteLine("--------------------------------------");

            var o1 = new Obj("Teste1");
            var o2 = new Obj("Teste2");
            var o3 = new Obj("Teste3");
            var o4 = new Obj("Teste4");
            var o5 = new Obj("Teste5");
            var o6 = new Obj("Teste6");
            var o7 = new Obj("Teste7");
            var o8 = new Obj("Teste8");
            var o9 = new Obj("Teste9");
            var o10 = new Obj("Teste10");

            var hash2 = new MyHashSet<Obj>(5);
            hash2.Add(o1);
            hash2.Add(o2);
            hash2.Add(o3);
            hash2.Add(o4);
            hash2.Add(o5);
            hash2.Add(o7);
            hash2.Add(o8);
            hash2.Add(o9);
            hash2.Add(o10);

            hash2.RemoveKey(o2);

            Console.WriteLine(hash2.HasKey(o1));
            Console.WriteLine(hash2.HasKey(o2));
            Console.WriteLine(hash2.HasKey(o3));
            Console.WriteLine(hash2.HasKey(o4));
            Console.WriteLine(hash2.HasKey(o5));
            Console.WriteLine(hash2.HasKey(o6));
            Console.WriteLine(hash2.HasKey(o7));
            Console.WriteLine(hash2.HasKey(o8));
            Console.WriteLine(hash2.HasKey(o9));
            Console.WriteLine(hash2.HasKey(o10));
        }
    }
}

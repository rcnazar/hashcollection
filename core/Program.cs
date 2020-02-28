using System;
using System.Collections.Generic;
using System.Linq;
using MyCollection.Hash;


namespace hashcollection
{

	public class Obj
	{
		public int Val { get; set; }

		public override int GetHashCode()
		{
			return Val.GetHashCode();
		}
	}

	class Program
    {
        static void Main(string[] args)
        {
			//var h = new H.HashSet<Obj>();
			//h.Add(new Obj { Val = 1 });
			//h.Add(new Obj { Val = 1 });
			//h.Add(new Obj { Val = 2 });
			//h.Add(new Obj { Val = 3 });

			//var a = new HashSet<int>();

			//         var hash1 = new MyHashSet<int>();
			//         hash1.Add(1);

			//         Console.WriteLine(hash1.Contains(1));
			//         Console.WriteLine(hash1.Contains(2));
			//         Console.WriteLine(hash1.Contains(3));

			//         Console.WriteLine("--------------------------------------");

			//         var o1 = new Obj("Teste1");
			//         var o2 = new Obj("Teste2");
			//         var o3 = new Obj("Teste3");
			//         var o4 = new Obj("Teste4");
			//         var o5 = new Obj("Teste5");
			//         var o6 = new Obj("Teste6");
			//         var o7 = new Obj("Teste7");
			//         var o8 = new Obj("Teste8");
			//         var o9 = new Obj("Teste9");
			//         var o10 = new Obj("Teste10");

			//         var hash2 = new MyHashSet<Obj>(5);
			//         hash2.Add(o1);
			//         hash2.Add(o2);
			//         hash2.Add(o3);
			//         hash2.Add(o4);
			//         hash2.Add(o5);
			//         hash2.Add(o7);
			//         hash2.Add(o8);
			//         hash2.Add(o9);
			//         hash2.Add(o10);

			//         hash2.Remove(o2);

			//         Console.WriteLine(hash2.Contains(o1));
			//         Console.WriteLine(hash2.Contains(o2));
			//         Console.WriteLine(hash2.Contains(o3));
			//         Console.WriteLine(hash2.Contains(o4));
			//         Console.WriteLine(hash2.Contains(o5));
			//         Console.WriteLine(hash2.Contains(o6));
			//         Console.WriteLine(hash2.Contains(o7));
			//         Console.WriteLine(hash2.Contains(o8));
			//         Console.WriteLine(hash2.Contains(o9));
			//         Console.WriteLine(hash2.Contains(o10));


			var qtd =  100000;
			var qtd2 = 100000;
			var watch = System.Diagnostics.Stopwatch.StartNew();

			var list = new List<int>();
			for (var i = 0; i < qtd2; i++)
			{
				list.Add(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);
			watch.Restart();

			for (var i = 0; i < qtd2; i++)
			{
				list.Contains(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);








			watch.Restart();

			var hash = new MyHashSet<int>(qtd2 * 2);
			for (var i = 0; i < qtd2; i++)
			{
				hash.Add(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);
			watch.Restart();

			for (var i = 0; i < qtd2; i++)
			{
				hash.Contains(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);









			watch.Restart();

			var hash2 = new HashSet<int>();
			for (var i = 0; i < qtd; i++)
			{
				hash2.Add(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);
			watch.Restart();

			for (var i = 0; i < qtd; i++)
			{
				hash2.Contains(i);
			}

			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);
		}
    }
}

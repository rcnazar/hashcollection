using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollection.Hash;

namespace test
{
    [TestClass]
    public class HashSetTest
    {
        [TestMethod]
        public void AddItem()
        {
			var a = new int[10];

            var set = new MyHashSet<int>();

            set.Add(1);

            Assert.IsTrue(set.Contains(1));
            Assert.IsFalse(set.Contains(2));
            Assert.IsFalse(set.Contains(3));
        }

        [TestMethod]
        public void RemoveItem()
        {
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

            var set = new MyHashSet<Obj>();
            set.Add(o1);
            set.Add(o2);
            set.Add(o3);
            set.Add(o4);
            set.Add(o5);
            set.Add(o7);
            set.Add(o8);
            set.Add(o9);
            set.Add(o10);

            set.Remove(o2);

            Assert.IsTrue(set.Contains(o1));
            Assert.IsFalse(set.Contains(o2));
            Assert.IsTrue(set.Contains(o3));
            Assert.IsTrue(set.Contains(o4));
            Assert.IsTrue(set.Contains(o5));
            Assert.IsFalse(set.Contains(o6));
            Assert.IsTrue(set.Contains(o7));
            Assert.IsTrue(set.Contains(o8));
            Assert.IsTrue(set.Contains(o9));
            Assert.IsTrue(set.Contains(o10));
        }

        [TestMethod]
        public void Rehasing()
        {
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

            var set = new MyHashSet<Obj>(5);
            set.Add(o1);
            set.Add(o2);
            set.Add(o3);
            set.Add(o4);
            set.Add(o5);
            set.Add(o7);
            set.Add(o8);
            set.Add(o9);
            set.Add(o10);

            set.Remove(o2);

            Assert.IsTrue(set.Contains(o1));
            Assert.IsFalse(set.Contains(o2));
            Assert.IsTrue(set.Contains(o3));
            Assert.IsTrue(set.Contains(o4));
            Assert.IsTrue(set.Contains(o5));
            Assert.IsFalse(set.Contains(o6));
            Assert.IsTrue(set.Contains(o7));
            Assert.IsTrue(set.Contains(o8));
            Assert.IsTrue(set.Contains(o9));
            Assert.IsTrue(set.Contains(o10));
        }

        private class Obj
        {
            public string Value { get; set; }

            public Obj(string value)
            {
                Value = value;
            }
        }
    }
}

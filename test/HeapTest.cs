using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollection.Heap;
using System;
using System.ComponentModel;

namespace test
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void GetFirst()
        {
            var set = new Heap<int>();

            set.Add(1);
            set.Add(3);
            set.Add(2);

            Assert.AreEqual(1, set.Get());
            Assert.AreEqual(1, set.Get());
        }

        [TestMethod]
        public void GetFirstMax()
        {
            var set = new Heap<int>(ListSortDirection.Descending);

            set.Add(1);
            set.Add(3);
            set.Add(2);

            Assert.AreEqual(3, set.Get());
            Assert.AreEqual(3, set.Get());
        }

        [TestMethod]
        public void ExtractFirst()
        {
            var set = new Heap<int>();

            set.Add(1);
            set.Add(3);
            set.Add(2);

            Assert.AreEqual(1, set.Extract());
            Assert.AreEqual(2, set.Extract());
            Assert.AreEqual(3, set.Extract());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => set.Extract());
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollection.Hash;

namespace test
{
    [TestClass]
    public class HashTableTest
	{
        [TestMethod]
        public void AddItem()
        {
            var set = new MyHashTable<string, int>();

            set.Add("Ricardo", 30);
            set.Add("Hadassa", 29);

			Assert.IsTrue(set.Contains("Ricardo"));
            Assert.IsTrue(set.Contains("Hadassa"));
            Assert.IsFalse(set.Contains("Pedro"));
			Assert.AreEqual(30, set["Ricardo"]);
			Assert.AreEqual(29, set["Hadassa"]);

		}

		[TestMethod] 
		public void AddItemIndexer()
		{
			var set = new MyHashTable<string, int>();

			set["Ricardo"] = 30;
			set["Hadassa"] = 29;

			Assert.IsTrue(set.Contains("Ricardo"));
			Assert.IsTrue(set.Contains("Hadassa"));
			Assert.IsFalse(set.Contains("Pedro"));
			Assert.AreEqual(30, set["Ricardo"]);
			Assert.AreEqual(29, set["Hadassa"]);

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

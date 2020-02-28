using core.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
	[TestClass]
	public class MovieWatchedTimeTest
	{
		[TestMethod]
		public void Case1()
		{
			var list = new List<(int begin, int end)>
			{
				(30, 40),
				(10, 35),
			};

			var retorno = MovieWatchedTime.Get(list);

			Assert.AreEqual(30, retorno);
		}

		[TestMethod]
		public void Case2()
		{
			var list = new List<(int begin, int end)>
			{
				(30, 40),
				(0, 10),
			};

			var retorno = MovieWatchedTime.Get(list);

			Assert.AreEqual(20, retorno);
		}
	}
}

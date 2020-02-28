using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Exercise
{
	public static class MovieWatchedTime
	{
		public static object Get(List<(int begin, int end)> list)
		{
			var final = list
				.OrderBy(a => a.begin)
				.Merge();

			return final
				.Sum(a => a.end - a.begin);
		}

		private static IEnumerable<(int begin, int end)> Merge(this IEnumerable<(int begin, int end)> list)
		{
			(int begin, int end)? curr = null;

			foreach (var item in list)
			{
				if (!curr.HasValue)
				{
					curr = (item.begin, item.end);
					continue;
				}

				if (item.begin < curr.Value.end &&
						item.end > curr.Value.end)
				{
					curr = (curr.Value.begin, item.end);
				}
				else if (item.begin > curr.Value.end)
				{
					yield return curr.Value;
					curr = (item.begin, item.end);
				}
			}

			if (curr.HasValue)
			{ 
				yield return curr.Value;
			}
		}
	}
}

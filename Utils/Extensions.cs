using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
	public static class Extensions
	{
		public static void SafeIncrement<TKey>(this Dictionary<TKey, long> dict, TKey key, long value)
		{
			if (!dict.ContainsKey(key))
			{
				dict.Add(key, 0);
			}

			dict[key] += value;
		}
	}
}

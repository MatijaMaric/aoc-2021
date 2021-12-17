using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class ReaderBoy
	{
		private string _string;

		public ReaderBoy(string s)
		{
			_string = s;
		}

		public string? Read()
		{
			return Read(1);
		}

		public string? Read(int i)
		{
			if (_string.Length < i)
			{
				return null;
			}

			var ans = _string[..i];
			_string = _string[i..];
			return ans;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	public enum PacketType
	{
		Sum = 0,
		Product = 1,
		Minimum = 2,
		Maximum = 3,
		Literal = 4,
		GreaterThan = 5,
		LessThan = 6,
		Equal = 7,
	}
}

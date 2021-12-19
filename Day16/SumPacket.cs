using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class SumPacket : OperatorPacket
	{
		public SumPacket(int version, ReaderBoy bits) : base(version, PacketType.Sum, bits)
		{
		}

		public override long Value => SubPackets.Sum(x => x.Value);
	}
}

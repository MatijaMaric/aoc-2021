using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class LessThanPacket : OperatorPacket
	{
		public LessThanPacket(int version, ReaderBoy bits) : base(version, PacketType.LessThan, bits)
		{
		}

		public override long Value => SubPackets[0].Value < SubPackets[1].Value ? 1 : 0;
	}
}

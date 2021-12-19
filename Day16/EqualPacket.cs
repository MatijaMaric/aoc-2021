using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class EqualPacket : OperatorPacket
	{
		public EqualPacket(int version, ReaderBoy bits) : base(version, PacketType.Equal, bits)
		{
		}

		public override long Value => SubPackets[0].Value == SubPackets[1].Value ? 1 : 0;

	}
}

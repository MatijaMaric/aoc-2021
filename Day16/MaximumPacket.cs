using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class MaximumPacket : OperatorPacket
	{
		public MaximumPacket(int version, ReaderBoy bits) : base(version, PacketType.Maximum, bits)
		{
		}

		public override long Value => SubPackets.Max(x => x.Value);
	}
}

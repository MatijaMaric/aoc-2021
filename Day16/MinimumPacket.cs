using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class MinimumPacket : OperatorPacket
	{
		public MinimumPacket(int version, ReaderBoy bits) : base(version, PacketType.Minimum, bits)
		{
		}

		public override long Value => SubPackets.Min(x => x.Value);
	}
}

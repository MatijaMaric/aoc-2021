using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class ProductPacket : OperatorPacket
	{
		public ProductPacket(int version, ReaderBoy bits) : base(version, PacketType.Product, bits)
		{
		}

		public override long Value => SubPackets.Aggregate(1L, (acc, p) => acc * p.Value);
	}
}

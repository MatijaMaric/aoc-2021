using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class LiteralPacket : Packet
	{
		public LiteralPacket(int version, ReaderBoy bits) : base(version, PacketType.Literal, bits)
		{
		}

		public int Value { get; set; }

		protected override bool Consume(ReaderBoy bits)
		{
			while (true)
			{
				var head = bits.Read();
				Length += 1;
				if (head == null)
				{
					return false;
				}

				var body = bits.Read(4);
				Length += 4;
				if (body == null)
				{
					return false;
				}

				Value *= 16;
				Value += Convert.ToInt32(body, 2);

				if (head == "0")
				{
					break;
				}
			}

			return true;
		}
	}
}

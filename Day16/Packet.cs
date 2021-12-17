namespace Day16
{
	internal abstract class Packet
	{
		public int Version { get; set; }
		public PacketType Type { get; set; }

		public int Length { get; protected set; }

		protected Packet(int version, PacketType type, ReaderBoy bits)
		{
			Version = version;
			Type = type;
			Length = 6;
		}

		protected abstract bool Consume(ReaderBoy bits);

		public static Packet? CreatePacket(ReaderBoy bits)
		{
			var version = Convert.ToInt32(bits.Read(3), 2);
			var type = (PacketType)Convert.ToInt32(bits.Read(3), 2);

			Packet packet = type switch
			{
				PacketType.Literal => new LiteralPacket(version, bits),
				_ => new OperatorPacket(version, type, bits)
			};

			if (packet.Consume(bits))
			{
				return packet;
			}

			return null;
		}
	}

}

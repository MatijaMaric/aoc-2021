namespace Day16
{
	internal class OperatorPacket : Packet
	{
		enum LengthType
		{
			None = -1,
			Subpackets = 1,
			TotalBits = 0
		}

		private LengthType _lengthType = LengthType.None;
		private int _length = -1;
		private List<Packet> _packets = new List<Packet>();

		public OperatorPacket(int version, PacketType type, ReaderBoy bits) : base(version, type, bits)
		{
		}

		protected override bool Consume(ReaderBoy bits)
		{
			var type = bits.Read();
			if (type == null)
			{
				return false;
			}
			Length += 1;

			_lengthType = type == "1" ? LengthType.Subpackets : LengthType.TotalBits;

			var length = bits.Read(_lengthType == LengthType.Subpackets ? 11 : 15);
			if (length == null)
			{
				return false;
			}
			Length += length.Length;
			_length = Convert.ToInt32(length, 2);

			if (_lengthType == LengthType.TotalBits)
			{
				while (_length > 0)
				{
					var packet = CreatePacket(bits);
					if (packet == null)
					{
						return false;
					}

					_length -= packet.Length;
					Length += packet.Length;
					_packets.Add(packet);
				}
			} else if (_lengthType == LengthType.Subpackets)
			{
				for (var i = 0; i < _length; i++)
				{
					var packet = CreatePacket(bits);
					if (packet == null)
					{
						return false;
					}

					Length += packet.Length;
					_packets.Add(packet);
				}
			}

			return true;
		}
	}
}

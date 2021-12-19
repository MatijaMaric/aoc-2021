using Day16;
using Utils;

var input = await Input.GetDayAsync(16);
var binary = string.Join(string.Empty,
	input.Trim().Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')));
var packet = Packet.CreatePacket(new ReaderBoy(binary));

if (packet == null)
{
	Console.WriteLine("corrupted packet");
	return;
}

var sumVersion = 0;
var q = new Queue<Packet>();
q.Enqueue(packet);
while (q.Any())
{
	var c = q.Dequeue();
	sumVersion += c.Version;

	if (c is OperatorPacket op)
	{
		op.SubPackets.ForEach(q.Enqueue);
	}
}

Console.WriteLine(sumVersion);
Console.WriteLine(packet.Value);

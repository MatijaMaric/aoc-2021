using Day16;
using Utils;

var input = await Input.GetDayAsync(16);
input = "A0016C880162017C3686B18A3D4780";
var binary = string.Join("", input.ToCharArray().Select(x => Convert.ToInt32(x.ToString(), 16)).Select(x => Convert.ToString(x, 2)));

Console.WriteLine(binary);

var packet = Packet.CreatePacket(new ReaderBoy(binary));

Console.WriteLine("boi");

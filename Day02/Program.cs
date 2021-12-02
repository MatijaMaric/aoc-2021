
using Utils;

var input = await Input.GetDayAsync(2);
var lines = input.Trim().Split('\n');

int x = 0, y = 0;
int aim = 0, hor = 0, dep = 0;

foreach (var line in lines)
{
	var instr = line.Split(' ');
	var val = int.Parse(instr[1]);
	switch (instr[0])
	{
		case "forward":
			x += val;
			hor += val;
			dep += aim * val;
			break;
		case "down":
			y += val;
			aim += val;
			break;
		case "up":
			y -= val;
			aim -= val;
			break;
		default:
			throw new Exception(line);
	}
}

Console.WriteLine(x * y);
Console.WriteLine(dep * hor);

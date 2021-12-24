using System.Text.RegularExpressions;
using Utils;

var input = await Input.GetDayAsync(17);
//input = "target area: x=20..30, y=-10..-5";
var regex = new Regex(@"target area: x=(?<x0>.*)\.\.(?<x1>.*), y=(?<y0>.*)\.\.(?<y1>.*)");
var g = regex.Match(input);

var x0 = int.Parse(g.Groups["x0"].Value);
var x1 = int.Parse(g.Groups["x1"].Value);
var y0 = int.Parse(g.Groups["y0"].Value);
var y1 = int.Parse(g.Groups["y1"].Value);

var minX = Math.Min(x0, x1);
var maxX = Math.Max(x0, x1);
var minY = Math.Min(y0, y1);
var maxY = Math.Max(y0, y1);

bool TrySolve(int vx0, int vy0, out int peakY)
{
	int x = 0, y = 0;
	int vx = vx0, vy = vy0;
	peakY = 0;
	while (x <= maxX && y >= minY)
	{
		x += vx;
		if (vx > 0)
		{
			vx--;
		}
		else if (vx < 0)
		{
			vx++;
		}
		y += vy--;
		peakY = Math.Max(peakY, y);

		if (x >= minX && x <= maxX && y >= minY && y <= maxY)
		{
			return true;
		}
	}

	return false;
}

var bestY = 0;
var fromX = -Math.Max(Math.Abs(minX), Math.Abs(maxX))*2;
var toX = -fromX;
var fromY = -Math.Max(Math.Abs(minY), Math.Abs(maxY))*2;
var toY = -fromY;
var hits = 0;

TrySolve(6, 0, out var test);
Console.WriteLine(test);

for (var vx = fromX; vx <= toX; vx++)
{
	for (var vy = fromY; vy <= toY; vy++)
	{
		if (TrySolve(vx, vy, out var peakY))
		{
			bestY = Math.Max(bestY, peakY);
			hits++;
			//Console.WriteLine($"{vx}, {vy}");
		}
	}
}

Console.WriteLine(bestY);
Console.WriteLine(hits);

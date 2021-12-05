using Day05;
using Utils;

var input = await Input.GetDayAsync(5);

var lines = input.Trim().Split('\n').Select(x => new Line(x)).ToList();

var map = new Dictionary<(int, int), int>();

foreach (var line in lines)
{
	foreach (var (X, Y) in line.GetPoints(true))
	{
		if (!map.ContainsKey((X, Y)))
		{
			map.Add((X, Y), 1);
		} else
		{
			map[(X, Y)]++;
		}
	}
}

var score = 0;
foreach (var point in map.Values)
{
	if (point > 1)
	{
		score++;
	}
}

Console.WriteLine(score);

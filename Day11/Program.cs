using Utils;

var input = await Input.GetDayAsync(11);
//input = @"5483143223
//2745854711
//5264556173
//6141336146
//6357385478
//4167524645
//2176841721
//6882881134
//4846848554
//5283751526";

var levels = input.Trim().Split('\n').Select(x => x.ToCharArray().Select(x => x - '0').ToArray()).ToArray();

//const int steps = 100;
var flashes = 0;
var steps = 0;
while (true)
{
	steps++;
	var flashed = new HashSet<(int, int)>();
	var newLevels = new int[levels.Length][];

	for (var x = 0; x < levels.Length; x++)
	{
		newLevels[x] = new int[levels[x].Length];
		for (var y = 0; y < levels[x].Length; y++)
		{
			newLevels[x][y] = levels[x][y] + 1;
			if (newLevels[x][y] > 9)
			{
				flashed.Add((x, y));
			}
		}
	}

	var oldFlashed = new HashSet<(int, int)>(flashed);
	while (oldFlashed.Any())
	{
		var newFlashed = new HashSet<(int, int)>();
		foreach (var (x, y) in oldFlashed)
		{
			foreach (var (dx, dy) in Helpers.GridMovement(true))
			{
				if (x + dx >= 0 && y + dy >= 0 && x + dx < newLevels.Length && y + dy < newLevels[x].Length)
				{
					newLevels[x + dx][y + dy]++;
					if (!flashed.Contains((x+dx,y+dy)) && newLevels[x + dx][y+dy] > 9)
					{
						flashed.Add((x + dx, y + dy));
						newFlashed.Add((x + dx, y + dy));
					}
				}
			}
		}

		oldFlashed = newFlashed;
	}

	foreach (var (x,y) in flashed)
	{
		newLevels[x][y] = 0;
	}

	flashes += flashed.Count;
	if (flashed.Count == 100)
	{
		Console.WriteLine($"First {steps}");
		break;
	}
	levels = newLevels;
}

Console.WriteLine(flashes);

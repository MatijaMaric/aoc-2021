using Utils;

var input = await Input.GetDayAsync(9);


var grid = input.Trim().Split('\n').Select(x => x.ToCharArray().Select(x => x - '0').ToArray()).ToArray();
var lowPoints = new List<(int, int)>();

var ans = 0;
for (var x = 0; x < grid.Length; x++)
{
	for (var y = 0; y < grid[x].Length; y++)
	{
		var isMin = true;
		foreach (var (dx, dy) in Helpers.GridMovement())
		{
			if (dx == 0 && dy == 0)
			{
				continue;
			}

			if (x + dx < 0 || x + dx == grid.Length || y + dy < 0 || y + dy == grid[x].Length)
			{
				continue;
			}

			if (grid[x][y] >= grid[x + dx][y + dy])
			{
				isMin = false;
				break;
			}
		}
		if (isMin)
		{
			ans += 1 + grid[x][y];
			lowPoints.Add((x, y));
		}
	}
}

var basins = new List<int>();

foreach (var (x, y) in lowPoints)
{
	basins.Add(Helpers.Flood(grid, 9, x, y));
}

basins.Sort();
basins.Reverse();

Console.WriteLine(ans);
Console.WriteLine(basins[0] * basins[1] * basins[2]);

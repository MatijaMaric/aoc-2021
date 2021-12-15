using Utils;

var input = await Input.GetDayAsync(15);
//input = @"1163751742
//1381373672
//2136511328
//3694931569
//7463417111
//1319128137
//1359912421
//3125421639
//1293138521
//2311944581";

var grid = input.Trim().Split('\n').Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();

var width = grid.Length;
var height = grid[0].Length;

var biggerGrid = new int[width * 5][];
for (var i = 0; i < width * 5; i++)
{
	biggerGrid[i] = new int[height*5];
}

for (var x = 0; x < width; x++)
{
	for (var y = 0; y < height; y++)
	{
		for (var i = 0; i < 5; i++)
		{
			for (var j = 0; j < 5; j++)
			{
				var newValue = grid[x][y] + i+j;
				if (newValue > 9)
				{
					newValue -= 9;
				}
				biggerGrid[width * i + x][height * j + y] = newValue;
			}
		}
	}
}

grid = biggerGrid;
width = grid.Length;
height = grid[0].Length;

var dist = new Dictionary<(int x, int y), int>();
for (var x = 0; x < width; x++)
{
	for (var y = 0; y < height; y++)
	{
		dist.Add((x, y), int.MaxValue);
	}
}

var queue = new HashSet<(int x, int y)>();
dist[(0, 0)] = 0;
queue.Add((0, 0));
var visited = new HashSet<(int x, int y)>();

while (queue.Any())
{
	var (x, y) = queue.MinBy(v => dist[v]);
	queue.Remove((x, y));
	visited.Add((x, y));

	foreach (var (dx, dy) in Helpers.GridMovement())
	{
		if (x + dx < 0 || y + dy < 0 || x + dx == width || y + dy == height)
		{
			continue;
		}

		if (visited.Contains((x + dx, y + dy)))
		{
			continue;
		}

		var next = dist[(x, y)] + grid[x + dx][y + dy];
		if (next < dist[(x + dx, y + dy)])
		{
			dist[(x + dx, y + dy)] = next;
		}

		queue.Add((x + dx, y + dy));
	}

}

Console.WriteLine(dist[(width - 1, height - 1)]);

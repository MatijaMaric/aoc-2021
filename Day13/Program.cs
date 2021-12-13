using Utils;

var input = await Input.GetDayAsync(13);

//var input = @"6,10
//0,14
//9,10
//0,3
//10,4
//4,11
//6,0
//6,12
//4,1
//0,13
//10,12
//3,4
//3,0
//8,4
//1,10
//2,14
//8,10
//9,0

//fold along y=7
//fold along x=5";

var s = input.Trim().Split("\n\n");
var dots = s[0].Split('\n').Select(x => x.Split(',').Select(int.Parse).ToArray());
var folds = s[1].Split('\n').Select(x => x.Substring(11).Split('=')).ToList();

var grid = new HashSet<(int x, int y)>();
var width = 0;
var height = 0;

foreach (var dot in dots)
{
	grid.Add((dot[0], dot[1]));
	if (dot[0] > width)
	{
		width = dot[0];
	}

	if (dot[1] > height)
	{
		height = dot[1];
	}
}

foreach (var fold in folds)
{
	var newGrid = new HashSet<(int x, int y)>();
	var axis = fold[0];
	var w = int.Parse(fold[1]);

	width = 0;
	height = 0;

	foreach (var (x, y) in grid)
	{
		if (x > width)
		{
			width = x;
		}

		if (y > height)
		{
			height = y;
		}
		if (axis == "y")
		{
			if (y < w)
			{
				newGrid.Add((x, y));
			}
			else if (y - w >= 0)
			{
				newGrid.Add((x, 2 * w - y));
			}
		}
		else
		{
			if (x < w)
			{
				newGrid.Add((x, y));
			}
			else if (x - w >= 0)
			{
				newGrid.Add((2 * w - x, y));
			}
		}
	}

	grid = newGrid;
}


//for (var x = 0; x < width; x++)
//{
//	for (var y = 0; y < height; y++)
//	{
//		Console.Write(grid.Contains((x, y)) ? "#" : ".");
//	}
//	Console.WriteLine();
//}
//Console.WriteLine();
	for (var y = 0; y <= height; y++)
{
for (var x = 0; x <= width; x++)
	{
		Console.Write(grid.Contains((x, y)) ? "#" : ".");
	}
	Console.WriteLine();
}

//Console.WriteLine(newGrid.Count);

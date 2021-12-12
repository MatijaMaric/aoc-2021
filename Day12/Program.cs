using Utils;

var input = await Input.GetDayAsync(12);
//input = @"fs-end
//he-DX
//fs-he
//start-DX
//pj-DX
//end-zg
//zg-sl
//zg-pj
//pj-he
//RW-he
//fs-DX
//pj-RW
//zg-RW
//start-pj
//he-WI
//zg-he
//pj-fs
//start-RW";

var lines = input.Trim().Split('\n');

var edges = new Dictionary<string, List<string>>();

foreach (var line in lines)
{
	var split = line.Split('-');
	if (!edges.ContainsKey(split[0]))
	{
		edges.Add(split[0], new List<string>());
	}
	if (!edges.ContainsKey(split[1]))
	{
		edges.Add(split[1], new List<string>());
	}

	edges[split[0]].Add(split[1]);
	edges[split[1]].Add(split[0]);
}

var paths = new HashSet<string>();

var queue = new Queue<(string node, string path, HashSet<string> visited, string twice)>();
queue.Enqueue(("start", "start", new HashSet<string>(), ""));

while (queue.Any())
{
	var (node, path, visited, twice) = queue.Dequeue();

	if (node == "end")
	{
		paths.Add(path);
		continue;
	}

	if (visited.Contains(node))
	{
		if (node != "start" && node.ToLower() == node && twice == "")
		{
			twice = node;
		}
		else
		{
			continue;
		}
	};

	if (node.ToUpper() != node)
	{
		visited.Add(node);
	}

	var possible = edges[node];

	foreach (var next in possible)
	{
		queue.Enqueue((next, $"{path},{next}", new HashSet<string>(visited), twice));
	}
}

//foreach (var path in paths.OrderBy(x => x))
//{
//	Console.WriteLine(path);
//}

Console.WriteLine(paths.Count);

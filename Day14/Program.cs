using Utils;

var input = await Input.GetDayAsync(14);
//input = @"NNCB

//CH -> B
//HH -> N
//CB -> H
//NH -> C
//HB -> C
//HC -> B
//HN -> C
//NN -> C
//BH -> H
//NC -> B
//NB -> B
//BN -> B
//BB -> N
//BC -> B
//CC -> N
//CN -> C";

var s = input.Trim().Split("\n\n");

var polymer = s[0];
var rules = new Dictionary<string, (string, string)>();

foreach (var rule in s[1].Split('\n'))
{
	var w = rule.Split(" -> ");
	rules.Add(w[0], ($"{w[0][0]}{w[1]}", $"{w[1]}{w[0][1]}"));
}

var steps = 40;
var counts = new Dictionary<string, long>();

for (var i = 0; i < polymer.Length - 1; i++)
{
	var pair = polymer[i..(i + 2)];
	counts.SafeIncrement(pair, 1);
}

for (var i = 0; i < steps; i++)
{
	var newCounts = new Dictionary<string, long>();
	foreach (var (pair, count) in counts)
	{
		if (rules.ContainsKey(pair))
		{
			var (left, right) = rules[pair];
			newCounts.SafeIncrement(left, count);
			newCounts.SafeIncrement(right, count);
		}
		else
		{
			newCounts.SafeIncrement(pair, count);
		}
	}

	counts = newCounts;
}

var perChar = new Dictionary<char, long>();
foreach (var (pair, count) in counts)
{
	perChar.SafeIncrement(pair[0], count);
	perChar.SafeIncrement(pair[1], count);
}

foreach (var c in perChar.Keys)
{
	if (perChar[c] % 2 == 1)
	{
		perChar[c]++;
	}
	perChar[c] /= 2;
}


Console.WriteLine(perChar.Values.Max() - perChar.Values.Min());

using Utils;

var input = await Input.GetDayAsync(8);

var lines = input.Trim().Split('\n');

var lens = new Dictionary<int, int>();
for (var i = 1; i <= 7; i++)
{
	lens[i] = 0;
}

int Decode(IEnumerable<string> patterns, IEnumerable<string> outputs)
{
	var sortedPatterns = patterns.Select(x => string.Join("", x.ToCharArray().OrderBy(x => x))).ToList();
	var sortedOutputs = outputs.Select(x => string.Join("", x.ToCharArray().OrderBy(x => x)));

	var one = sortedPatterns.Single(x => x.Length == 2);
	var four = sortedPatterns.Single(x => x.Length == 4);
	var seven = sortedPatterns.Single(x => x.Length == 3);
	var eight = sortedPatterns.Single(x => x.Length == 7);

	var six = sortedPatterns.Where(x => x.Length == 6).Single(x => x.Intersect(one).Count() == 1);

	var topRight = eight.Except(six).First();
	var bottomRight = one.Except(new[] { topRight }).First();

	var five = sortedPatterns.Where(x => x.Length == 5).Single(x => six.Except(x).Count() == 1);
	var bottomLeft = six.Except(five).First();

	var nine = sortedPatterns.Where(x => x.Length == 6).Single(x => !x.Contains(bottomLeft));
	var three = sortedPatterns.Where(x => x.Length == 5).Single(x => x.Contains(topRight) && !x.Contains(bottomLeft));
	var topLeft = eight.Except(three).Except(new[] { bottomLeft }).First();
	var two = sortedPatterns.Where(x => x.Length == 5).Single(x => !x.Contains(topLeft) && !x.Contains(bottomRight));
	var zero = sortedPatterns.Where(x => x.Length == 6).Single(x => x.Contains(topRight) && x.Contains(bottomLeft));

	var digits = new Dictionary<string, int>
	{
		{zero, 0},
		{one, 1},
		{two, 2},
		{three, 3},
		{four, 4},
		{five, 5},
		{six, 6},
		{seven, 7},
		{eight, 8},
		{nine, 9},
	};

	var res = 0;
	foreach (var output in sortedOutputs)
	{
		res = res * 10 + digits[output];
	}

	return res;
}

var sum = 0;
foreach (var line in lines)
{
	var digits = line.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
	var patterns = digits[..10];
	var outputs = digits[10..];
	sum += Decode(patterns, outputs);
	foreach (var output in outputs)
	{
		lens[output.Length]++;
	}
}

Console.WriteLine(lens[2] + lens[4] + lens[3] + lens[7]);
Console.WriteLine(sum);

using Utils;

var input = await Input.GetDayAsync(6);
var numbers = input.Trim().Split(',').Select(byte.Parse).ToList();
var counts = new long[9];

foreach (var number in numbers)
{
	counts[number]++;
}

var days = 256;

for (int i = 0; i < days; i++)
{
	var newCounts = new long[9];
	for (int j = 1; j <= 8; j++)
	{
		newCounts[j - 1] = counts[j];
	}
	newCounts[8] = counts[0];
	newCounts[6] += counts[0];
	counts = newCounts;
}

Console.WriteLine(counts.Sum());

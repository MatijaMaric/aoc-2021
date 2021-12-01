using Utils;

var input = await InputFetcher.GetDayAsync(1);

var split = input.Trim().Split('\n');
var numbers = split.Select(int.Parse).ToArray();
var res = 0;
var sums = new List<int>();

for (int i = 1; i < numbers.Length; i++)
{
	if (numbers[i] > numbers[i - 1])
	{
		res++;
	}
}


for (int i = 0; i < numbers.Length - 2; i++)
{
	sums.Add(numbers[i] + numbers[i + 1] + numbers[i + 2]);
}

var res2 = 0;

for (int i = 1; i < sums.Count; i++)
{
	if (sums[i] > sums[i - 1])
	{
		res2++;
	}
}

Console.WriteLine(res);
Console.WriteLine(res2);

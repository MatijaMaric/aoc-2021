using Utils;

var numbers = await Input.GetNumbersAsync(1);
var res = 0;
var sums = new List<int>();

for (int i = 1; i < numbers.Count; i++)
{
	if (numbers[i] > numbers[i - 1])
	{
		res++;
	}
}


for (int i = 0; i < numbers.Count - 2; i++)
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

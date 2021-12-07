
using Utils;

var input = await Input.GetDayAsync(7);

//input = "16,1,2,0,4,2,7,1,2,14";

var numbers = input.Trim().Split(',').Select(int.Parse).ToList();

var min = numbers.Min();
var max = numbers.Max();

int Cost(int x) => (x + 1) * x / 2;

var minFuel1 = int.MaxValue;
var minFuel2 = int.MaxValue;
for (int pos = min; pos <= max; pos++)
{
	var fuel1 = numbers.Select(x => Math.Abs(x - pos)).Sum();
	var fuel2 = numbers.Select(x => Cost(Math.Abs(x - pos))).Sum();
	if (fuel1 < minFuel1)
	{
		minFuel1 = fuel1;
	}
	if (fuel2 < minFuel2)
	{
		minFuel2 = fuel2;
	}
}

Console.WriteLine(minFuel1);
Console.WriteLine(minFuel2);

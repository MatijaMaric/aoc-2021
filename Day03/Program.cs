using Utils;

var input = await Input.GetDayAsync(3);

string gamma = "", epsilon = "";

var lines = input.Trim().Split("\n");

for (int i = 0; i < lines[0].Length; ++i)
{
	var ones = 0;
	var zeros = 0;
	for (int j = 0; j < lines.Length; ++j)
	{
		if (lines[j][i] == '1')
		{
			ones++;
		} else
		{
			zeros++;
		}
	}

	if (ones > zeros)
	{
		gamma += "1";
		epsilon += "0";
	} else
	{
		gamma += "0";
		epsilon += "1";
	}
}

var iGamma = Convert.ToInt32(gamma, 2);
var iEpsilon = Convert.ToInt32(epsilon, 2);
Console.WriteLine(iGamma * iEpsilon);

var oxygen = new string[lines.Length];
var co2 = new string[lines.Length];

int GetPart2(string[] numbers, bool most)
{
	var remaining = new List<string>(numbers);

	for (int i = 0; i < numbers[0].Length; ++i)
	{
		var ones = 0;
		var zeros = 0;

		for (int j = 0; j < remaining.Count; ++j)
		{
			if (remaining[j][i] == '1')
			{
				ones++;
			}
			else
			{
				zeros++;
			}
		}

		if (most ? ones > zeros : ones < zeros)
		{
			remaining = remaining.Where(x => x[i] == '1').ToList();
		} else if (most ? ones < zeros : ones > zeros)
		{
			remaining = remaining.Where(x => x[i] == '0').ToList();
		} else if (ones == zeros)
		{
			remaining = remaining.Where(x => x[i] == (most ? '1' : '0')).ToList();
		}
		if (remaining.Count == 1)
		{
			break;
		}
	}

	return Convert.ToInt32(remaining[0], 2);
}

lines.CopyTo(oxygen, 0);
lines.CopyTo(co2, 0);

var iOxygen = GetPart2(oxygen, true);
var iCo2 = GetPart2(co2, false);

Console.WriteLine(iOxygen * iCo2);

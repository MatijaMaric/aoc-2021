using Day04;
using Utils;

var input = await Input.GetDayAsync(4);

var split = input.Trim().Split("\n\n");

var numbers = split[0].Split(',').Select(int.Parse);
var bingosCards = split[1..];

var bingoNumbers = bingosCards.Select(x => new BingoCard(x)).ToList();

var drawn = new HashSet<int>();
var winners = new List<int>();

foreach (var number in numbers)
{
	drawn.Add(number);
	if (!bingoNumbers.Any())
	{
		break;
	}
	foreach (var card in bingoNumbers)
	{
		card.Draw(number);
		var score = card.CheckWin();
		if (score > 0)
		{
			winners.Add(score * number);
			bingoNumbers = bingoNumbers.Where(x => x != card).ToList();
		}
	}
}

Console.WriteLine(winners.First());
Console.WriteLine(winners.Last());

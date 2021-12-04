namespace Day04
{
	internal class BingoCard
	{
		public int[][] Numbers { get; private set; }
		private HashSet<int> drawn;
		private int[] rowHits, colHits;

		public BingoCard(string raw)
		{
			Numbers = parse(raw);
			rowHits = new int[5];
			colHits = new int[5];
			drawn = new HashSet<int>();
		}

		private int[][] parse(string raw)
		{
			return raw.Split('\n').Select(x => x.Split(new string[] {" ", "  "}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray()).ToArray();
		}

		internal void Draw(int number)
		{
			if (!drawn.Add(number))
			{
				return;
			}
			for (int i = 0; i < Numbers.Length; i++)
			{
				for (int j = 0; j < Numbers[i].Length; j++)
				{
					if (Numbers[i][j] == number)
					{
						rowHits[i]++;
						colHits[j]++;
						return;
					}
				}
			}
		}

		internal int CheckWin()
		{
			var win = rowHits.Any(x => x == 5) || colHits.Any(x => x == 5);

			if (win)
			{
				var score = 0;
				for (int i = 0; i < Numbers.Length; i++)
				{
					for (int j = 0; j < Numbers[i].Length; j++)
					{
						if (!drawn.Contains(Numbers[i][j]))
						{
							score += Numbers[i][j];
						}
					}
				}
				return score;
			}

			return -1;
		}
	}
}

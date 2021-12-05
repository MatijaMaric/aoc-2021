namespace Day05
{
	internal class Line
	{
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }

		public Line(string raw)
		{
			var split = raw.Split(new char[] { ' ', ',', '-', '>' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			X1 = int.Parse(split[0]);
			Y1 = int.Parse(split[1]);
			X2 = int.Parse(split[2]);
			Y2 = int.Parse(split[3]);
		}

		public IEnumerable<(int X, int Y)> GetPoints(bool diagonal = false)
		{
			if (X2 == X1)
			{
				var pre = Y1 > Y2 ? -1 : 1;
				for (int i = 0; i <= Math.Abs(Y2 - Y1); i++)
				{
					yield return (X1, Y1 + pre * i);
				}
			}
			if (Y2 == Y1)
			{
				var pre = X1 > X2 ? -1 : 1;
				for (int i = 0; i <= Math.Abs(X2 - X1); i++)
				{
					yield return (X1 + pre * i, Y1);
				}
			}

			if (!diagonal)
			{
				yield break;
			}

			if (Math.Abs(X2 - X1) == Math.Abs(Y2 - Y1))
			{
				var preX = X1 > X2 ? -1 : 1;
				var preY = Y1 > Y2 ? -1 : 1;
				for (int i = 0; i <= Math.Abs(X2 - X1); i++)
				{
					yield return (X1 + preX * i, Y1 + preY * i);
				}
			}

			yield break;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
	public static class Helpers
	{
		public static int Flood(int[][] grid, int wall, int startX, int startY)
		{
			var queue = new Queue<(int, int)>();
			var visited = new HashSet<(int, int)>();

			queue.Enqueue((startX, startY));
			while (queue.Count > 0)
			{
				var (x, y) = queue.Dequeue();
				if (visited.Contains((x, y)))
				{
					continue;
				}

				visited.Add((x, y));
				foreach (var (dx, dy) in GridMovement())
				{
					if (x + dx < 0 || x + dx == grid.Length || y + dy < 0 || y + dy == grid[0].Length)
					{
						continue;
					}

					if (grid[x + dx][y + dy] != wall)
					{
						queue.Enqueue((x + dx, y + dy));
					}
				}
			}

			return visited.Count;
		}

		public static IEnumerable<(int dx, int dy)> GridMovement(bool diagonal = false)
		{
			for (var dx = -1; dx <= 1; dx++)
			{
				for (var dy = -1; dy <= 1; dy++)
				{
					if (dx == 0 && dy == 0)
					{
						continue;
					}

					if (!diagonal && dx * dy != 0)
					{
						continue;
					}

					yield return (dx, dy);
				}
			}
		}
	}
}

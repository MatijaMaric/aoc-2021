
using System.Net;

namespace Utils
{
	public static class Input
	{
		private static string getCookie()
		{
			var env = readEnv();
			return env["SESSION_COOKIE"];
		}

		private static Dictionary<string, string> readEnv()
		{
			var env = File.ReadAllText(".env");
			return env.Trim().Split('\n').Select(line => line.Split(" = ")).ToDictionary(x => x[0], x => x[1]);
		}

		public static async Task<string> GetDayAsync(int day, int year = 2021)
		{
			var address = new Uri($"https://adventofcode.com/{year}/day/{day}/input");
			var cookies = new CookieContainer();

			using var handler = new HttpClientHandler() { CookieContainer = cookies };
			using var client = new HttpClient(handler) { BaseAddress = address };

			cookies.Add(address, new Cookie("session", getCookie()));

			var result = await client.GetAsync(address);
			result.EnsureSuccessStatusCode();

			return await result.Content.ReadAsStringAsync();
		}

		public static async Task<int[]> GetNumbersAsync(int day, int year = 2021)
		{
			var input = await GetDayAsync(day, year);

			return input.Trim().Split('\n').Select(int.Parse).ToArray();
		}
	}
}

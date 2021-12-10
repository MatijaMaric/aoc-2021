using Utils;

var input = await Input.GetDayAsync(10);

var lines = input.Trim().Split('\n');

char FindIllegal(string dirty)
{
	var stack = new Stack<char>();
	foreach (var c in dirty)
	{
		if (c is '(' or '<' or '{' or '[')
		{
			stack.Push(c);
			continue;
		}

		var left = stack.Pop();
		switch (left)
		{
			case '(':
				if (c != ')')
				{
					return c;
				}
				continue;
			case '[':
				if (c != ']')
				{
					return c;
				}
				continue;
			case '{':
				if (c != '}')
				{
					return c;
				}
				continue;
			case '<':
				if (c != '>')
				{
					return c;
				}
				continue;
		}
	}
	return '\0';
}

long score = 0;

var correctLines = new List<string>();

foreach (var line in lines)
{
	var illegal = FindIllegal(line);
	switch (illegal)
	{
		case ')':
			score += 3;
			continue;
		case ']':
			score += 57;
			continue;
		case '}':
			score += 1197;
			continue;
		case '>':
			score += 25137;
			continue;

		default:
			correctLines.Add(line);
			continue;
	}
}

Console.WriteLine(score);

long FinishLine(string line)
{
	var res = 0L;
	var stack = new Stack<char>();

	foreach (var c in line)
	{
		if (c is '(' or '<' or '{' or '[')
		{
			stack.Push(c);
			continue;
		}

		stack.Pop();
	}

	foreach (var c in stack)
	{
		res *= 5;
		switch (c)
		{
			case '(':
				res += 1;
				continue;
			case '[':
				res += 2;
				continue;
			case '{':
				res += 3;
				continue;
			case '<':
				res += 4;
				continue;
		}
	}
	return res;
}

var scores2 = correctLines.Select(FinishLine).ToList();
scores2.Sort();

Console.WriteLine(scores2[scores2.Count / 2]);

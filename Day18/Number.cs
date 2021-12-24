namespace Day18
{
	internal class Number
	{
		public Number? Parent { get; set; }

		public int? Value { get; set; }
		public Number? Left { get; set; }
		public Number? Right { get; set; }

		public Number(int value)
		{
			Value = value;
		}

		public bool Split()
		{
			if (Value is { } v)
			{
				if (v < 10)
				{
					return false;
				}

				Left = new Number(v / 2) { Parent = this };
				Right = new Number(v / 2 + v % 2) { Parent = this };
				Value = null;

				return true;
			}

			return Left!.Split() || Right!.Split();
		}

		public Number(Number a, Number b)
		{
			Left = a;
			Right = b;
		}

		private Number()
		{
		}

		public static Number Parse(string raw)
		{
			if (!raw.StartsWith('['))
			{
				return new Number(int.Parse(raw));
			}

			var next = raw.Substring(1, raw.Length - 2);
			var x = 0;
			var i = 0;
			while (next[i] != ',' || x != 0)
			{
				switch (next[i])
				{
					case '[':
						x++;
						break;
					case ']':
						x--;
						break;
				}

				i++;
			}

			var left = next[..i];
			var right = next[(i + 1)..];
			return Add(Parse(left), Parse(right));
		}

		public Number Add(int num)
		{
			Value += num;

			return this;
		}

		public static Number Add(Number a, Number b)
		{
			var next = new Number(a, b);
			a.Parent = next;
			b.Parent = next;

			return next;
		}

		public static Number Add(Number a, int num)
		{
			if (!a.Value.HasValue)
			{
				throw new Exception();
			}

			var next = new Number(a.Value.Value + num)
			{
				Parent = a.Parent
			};

			return next;
		}

		public static Number operator +(Number a, Number b) => Add(a, b);
		public static Number operator +(Number a, int num) => Add(a, num);

		public void Reduce()
		{
			while (true)
			{
				if (Explode())
				{
					continue;
				}
				if (Split())
				{
					continue;
				}
				break;
			}
		}

		private bool Explode()
		{
			var leftmost = Find();
			if (leftmost == null)
			{
				return false;
			}

			var leftValue = leftmost!.Left!.Value;
			var rightValue = leftmost!.Right!.Value;

			var last = leftmost;
			while (leftValue.HasValue)
			{
				var parent = last.Parent;
				if (parent == null)
				{
					break;
				}

				if (parent.Left == last)
				{
					last = parent;
					continue;
				}

				var target = parent.Left!.RightMost();
				target.Add(leftValue.Value);
				leftValue = null;
			}

			last = leftmost;
			while (rightValue.HasValue)
			{
				var parent = last.Parent;
				if (parent == null)
				{
					break;
				}

				if (parent.Right == last)
				{
					last = parent;
					continue;
				}

				var target = parent.Right!.LeftMost();
				target.Add(rightValue.Value);
				rightValue = null;
			}

			leftmost.Value = 0;
			leftmost.Left = null;
			leftmost.Right = null;

			return true;
		}

		public override string ToString()
		{
			return Value.HasValue ? Value.Value.ToString() : $"[{Left},{Right}]";
		}

		public int Magnitude()
		{
			if (Value.HasValue)
			{
				return Value.Value;
			}

			return 3 * Left!.Magnitude() + 2 * Right!.Magnitude();
		}

		public Number? Find(int depth = 4)
		{
			if (Value.HasValue)
			{
				return null;
			}

			if (depth <= 0 && Left!.Value.HasValue && Right!.Value.HasValue)
			{
				return this;
			}

			return Left!.Find(depth - 1) ?? Right!.Find(depth - 1);
		}

		public Number LeftMost()
		{
			return Value.HasValue ? this : Left!.LeftMost();
		}

		public Number RightMost()
		{
			return Value.HasValue ? this : Right!.RightMost();
		}
	}
}

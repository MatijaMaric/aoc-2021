using Day18;
using Utils;

var input = await Input.GetDayAsync(18);
//input = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
//[[[5,[2,8]],4],[5,[[9,9],0]]]
//[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
//[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
//[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
//[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
//[[[[5,4],[7,7]],8],[[8,3],8]]
//[[9,3],[[9,9],[6,[4,9]]]]
//[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
//[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

var numbers = input.Trim().Split('\n').Select(Number.Parse);

var numberList = numbers.ToList();
var sum = numberList.First();
//numbers = numberList.Skip(1);

//foreach (var number in numbers)
//{
//	sum += number;
//	sum.Reduce();
//}

var max = 0;

for (var i = 0; i < numberList.Count; ++i)
{
	for (var j = 0; j < numberList.Count; ++j)
	{
		if (i == j)
		{
			continue;
		}

		var s = Number.Parse(numberList[i].ToString()) + Number.Parse(numberList[j].ToString());
		s.Reduce();
		var mag = s.Magnitude();
		//Console.WriteLine(mag);
		max = Math.Max(max, mag);
	}
}

Console.WriteLine(sum.Magnitude());
Console.WriteLine(max);




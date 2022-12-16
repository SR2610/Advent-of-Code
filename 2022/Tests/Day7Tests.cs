using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day7Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(95437, Day7.SolvePartOne(Utils.GetDataFromFileAsLines("day7.txt", true)));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(24933642, Day7.SolvePartTwo(Utils.GetDataFromFileAsLines("day7.txt", true)));
		}
	}
}
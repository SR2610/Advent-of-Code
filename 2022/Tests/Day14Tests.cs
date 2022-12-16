using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day14Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(24, Day14.SolvePartOne(Utils.GetDataFromFileAsLines("day14.txt", true).ToArray()));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(93, Day14.SolvePartTwo(Utils.GetDataFromFileAsLines("day14.txt", true).ToArray()));
		}
	}
}
using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day8Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(21, Day8.SolvePartOne(Utils.GetDataFromFileAsLines("day8.txt", true).ToList()));
		}

		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(8, Day8.SolvePartTwo(Utils.GetDataFromFileAsLines("day8.txt", true).ToList()));
		}
	}
}
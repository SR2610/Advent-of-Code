using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day13Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(13, Day13.SolvePartOne(Utils.GetDataFromFileAsLines("day13.txt", true).ToArray()));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(140, Day13.SolvePartTwo(Utils.GetDataFromFileAsLines("day13.txt", true).ToArray()));
		}
	}
}
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day1Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(24000, Day1.CombinedSolver(1,Utils.GetDataFromFileAsLines("day1.txt",true)));
		}

		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(45000, Day1.CombinedSolver(3,Utils.GetDataFromFileAsLines("day1.txt",true)));
		}
	}
}
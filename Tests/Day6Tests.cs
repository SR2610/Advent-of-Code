using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day6Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(7, Day6.CheckForDistinctIndex(Utils.GetDataFromFile("day6.txt", true), 4));
		}

		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(19, Day6.CheckForDistinctIndex(Utils.GetDataFromFile("day6.txt", true), 14));
		}
	}
}
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day9Tests
	{
		
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(13, Day9.SolveRope(Utils.GetDataFromFileAsLines("day9.txt", true),2));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(36, Day9.SolveRope(Utils.GetDataFromFileAsLines("day9_additional.txt", true),10));
		}
	}
}
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
	}
}
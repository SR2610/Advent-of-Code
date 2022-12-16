using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day16Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(1651, Day16.SolvePartOne(Utils.GetDataFromFileAsLines("day16.txt", true).ToArray()));
		}
	}
}
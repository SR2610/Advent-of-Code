using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day10Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(13140, Day10.HandleInstructions(Utils.GetDataFromFileAsLines("day10.txt", true),false));
		}
		
	}
}
using System;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day1Tests
	{
		[Test]
		public void PartOneTest()
		{
			Console.Out.WriteLine("Test123");
			Assert.AreEqual(24001, Day1.CombinedSolver(1, Utils.GetDataFromFileAsLines("day1.txt", true)));
		}

		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(45000, Day1.CombinedSolver(3, Utils.GetDataFromFileAsLines("day1.txt", true)));
		}
	}
}
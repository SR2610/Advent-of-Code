using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day3Tests
    {
        [Test]
        public void PartOneTest()
        {
           Assert.AreEqual(157, Day3.SolvePartOne(Utils.GetDataFromFileAsLines("day3.txt", true)));
        }

        [Test]
        public void PartTwoTest()
        {
            //Assert.AreEqual(12, Day2.SolvePartTwo(Utils.GetDataFromFileAsLines("day2.txt", true)));
        }
    }
}
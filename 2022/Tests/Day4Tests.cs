using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day4Tests
    {
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(2, Day4.SolvePartOne(Utils.GetDataFromFileAsLines("day4.txt", true)));
        }

        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual(4, Day4.SolvePartTwo(Utils.GetDataFromFileAsLines("day4.txt", true)));
        }
    }
}
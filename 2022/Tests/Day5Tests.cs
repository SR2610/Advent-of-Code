using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day5Tests
    {
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual("CMZ", Day5.SolvePartOne(Utils.GetDataFromFileAsLines("day5.txt", true)));
        }
        
        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual("MCD", Day5.SolvePartTwo(Utils.GetDataFromFileAsLines("day5.txt", true)));
        }
    }
}
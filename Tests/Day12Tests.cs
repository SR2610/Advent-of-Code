using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day12Tests
    {
        
            [Test]
            public void PartOneTest()
            {
                Assert.AreEqual(31, Day12.SolvePartOne(Utils.GetDataFromFileAsLines("day12.txt", true).ToList()));
            }
		
            [Test]
            public void PartTwoTest()
            {
                Assert.AreEqual(29, Day12.SolvePartTwo(Utils.GetDataFromFileAsLines("day12.txt", true).ToList()));
            }
        
    }
}
using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day18Tests
    {
        
           
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(64, Day18.SolvePartOne(Utils.GetDataFromFileAsLines("day18.txt", true).ToArray()));
        }
        
    }
}
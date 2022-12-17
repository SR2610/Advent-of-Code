using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day17Tests
    {
        
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(3068, Day17.SolvePartOne(Utils.GetDataFromFile("day17.txt", true),2022));
        }
        
        [Test]
        public void PartTwoTest()
        {
            //Assert.AreEqual(1514285714288, Day17.SolvePartOne(Utils.GetDataFromFile("day17.txt", true),1000000000000));
        }
        
    }
}
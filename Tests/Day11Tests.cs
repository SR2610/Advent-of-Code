using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
    public class Day11Tests
    {
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(10605, Day11.DoMonkeyBusiness(Utils.GetDataFromFileAsLines("day11.txt", true).ToArray(),20,false));
        }
		
        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual(2713310158, Day11.DoMonkeyBusiness(Utils.GetDataFromFileAsLines("day11.txt", true).ToArray(),10000,true));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public class Day3
    {
        public static int SolvePartOne(IEnumerable<string> data)
        {
            int total = 0;
            foreach (string line in data)
            {

                string compartmentOne = line.Substring(0, line.Length / 2);
                string compartmentTwo = line.Substring(line.Length/2);
                string sharedLetters = "";
                foreach (char checkAgainst in compartmentOne.SelectMany(character => compartmentTwo.Where(checkAgainst => checkAgainst == character).Where(checkAgainst => !sharedLetters.Contains(checkAgainst))))
                {
                    sharedLetters += checkAgainst;
                }

                total += sharedLetters.Sum(c => char.ToUpper(c) - (char.IsUpper(c) ? 38 : 64));
            }


            return total;
        }

    }
}
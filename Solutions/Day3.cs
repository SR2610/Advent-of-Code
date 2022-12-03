using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day3
    {
        public static int SolvePartOne(IEnumerable<string> data)
        {
            int total = 0;
            foreach (string line in data)
            {
                string compartmentOne = line[..(line.Length / 2)];
                string compartmentTwo = line[(line.Length / 2)..];
                string sharedLetters = "";
                foreach (char checkAgainst in compartmentOne.SelectMany(character =>
                             compartmentTwo.Where(checkAgainst => checkAgainst == character)
                                 .Where(checkAgainst => !sharedLetters.Contains(checkAgainst))))
                    sharedLetters += checkAgainst;

                total += sharedLetters.Sum(GetLetterValue);
            }


            return total;
        }


        public static int SolvePartTwo(IEnumerable<string> data)
        {
            int total = 0;
            int currentGroupSize = 0;
            var groupBackpacks = new List<string>();
            foreach (string line in data)
            {
                currentGroupSize++;
                groupBackpacks.Add(line);
                if (currentGroupSize != 3) continue;
                string sharedLetters = "";
                foreach (char checkAgainst in groupBackpacks[0].SelectMany(character =>
                             groupBackpacks[1].Where(checkAgainst =>
                                 character == checkAgainst && !sharedLetters.Contains(checkAgainst))))
                    sharedLetters += checkAgainst;

                foreach (char sharedLetter in sharedLetters.Where(sharedLetter =>
                             groupBackpacks[2].Contains(sharedLetter)))
                {
                    total += GetLetterValue(sharedLetter);
                    break;
                }

                groupBackpacks.Clear();
                currentGroupSize = 0;
            }


            return total;
        }


        private static int GetLetterValue(char c)
        {
            return char.ToUpper(c) - (char.IsUpper(c) ? 38 : 64);
        }
    }
}
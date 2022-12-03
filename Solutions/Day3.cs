using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day3
    {
        public static int SolvePartOne(IEnumerable<string> data)
        {
            return (from line in data
                let compartmentOne = line[..(line.Length / 2)]
                let compartmentTwo = line[(line.Length / 2)..]
                select GetSharedCharacters(compartmentOne, compartmentTwo)
                into sharedLetters
                select sharedLetters.Sum(GetLetterValue)).Sum();
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
                string sharedLetters = GetSharedCharacters(groupBackpacks[0], groupBackpacks[1]);

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


        private static string GetSharedCharacters(string a, string b)
        {
            string result = "";

            foreach (char letterA in from letterA in a
                     from letterB in b
                     where letterA == letterB
                     where !result.Contains(letterA)
                     select letterA) result += letterA;

            return result;
        }

        private static int GetLetterValue(char c)
        {
            return char.ToUpper(c) - (char.IsUpper(c) ? 38 : 64);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day11
    {
        public static long DoMonkeyBusiness(string[] data, int cycles, bool panik)
        {
            long commonDivisor = 1;
            var monkeys = new List<Monkey>();
            for (int i = 0; i < data.Length; i += 7)
            {
                Monkey monkey = new Monkey();

                foreach (string item in data[i + 1].Split(": ")[1].Split(", ")) monkey.heldItems.Add(int.Parse(item));

                string[] operation = data[i + 2].Split("new = old ")[1].Split(" ");
                if (int.TryParse(operation[1], out int result))
                {
                    monkey.worryFactor = result;
                    monkey.worryType = operation[0] == "+" ? Monkey.WorryType.Add : Monkey.WorryType.Multiply;
                }
                else
                {
                    monkey.worryType = Monkey.WorryType.Square;
                }

                monkey.testFactor = int.Parse(data[i + 3].Split("by ")[1]);
                commonDivisor *= monkey.testFactor;
                monkey.trueOutput = int.Parse(data[i + 4].Split("monkey ")[1]);
                monkey.falseOutput = int.Parse(data[i + 5].Split("monkey ")[1]);


                monkeys.Add(monkey);
            }


            for (int i = 0; i < cycles; i++)
                foreach (Monkey monkey in monkeys)
                {
                    foreach (long item in monkey.heldItems)
                    {
                        long worryLevel = item;

                        switch (monkey.worryType)
                        {
                            case Monkey.WorryType.Add:
                                worryLevel += monkey.worryFactor;
                                break;
                            case Monkey.WorryType.Multiply:
                                worryLevel *= monkey.worryFactor;
                                break;
                            case Monkey.WorryType.Square:
                            default:
                                worryLevel *= worryLevel;
                                break;
                        }

                        if (panik)
                            worryLevel %= commonDivisor;
                        else
                            worryLevel /= 3;

                        monkeys[worryLevel % monkey.testFactor == 0 ? monkey.trueOutput : monkey.falseOutput].heldItems
                            .Add(worryLevel);
                        monkey.inspectedItems++;
                    }

                    monkey.heldItems.Clear();
                }

            var highest = monkeys.OrderByDescending(value => value.inspectedItems).Take(2).ToArray();


            return highest[0].inspectedItems * highest[1].inspectedItems;
        }
    }

    public class Monkey
    {
        public enum WorryType
        {
            Add,
            Multiply,
            Square
        }

        public readonly List<long> heldItems;

        public int falseOutput;
        public long inspectedItems;
        public int testFactor;
        public int trueOutput;
        public int worryFactor;

        public WorryType worryType;

        public Monkey()
        {
            heldItems = new List<long>();
            inspectedItems = 0;
        }
    }
}
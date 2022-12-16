using System;
using System.Collections.Generic;

namespace Advent_2022.Solutions
{
    public static class Day10
    {
        private const string Add = "addx";

        public static int HandleInstructions(IEnumerable<string> data, bool displayOutput)
        {
            var input = new Queue<string>(data);
            int cycle = 1, xRegister = 1, total = 0; //Why cycle and register start at 1 >:(
            int queuedInput = 0;
            while (input.Count > 0)
            {
                if (displayOutput)
                {
                    Console.Write(MathF.Abs((cycle - 1) % 40 - xRegister) <= 1 ? '#' : '.');
                    if (cycle % 40 == 0) Console.WriteLine();
                }

                if (queuedInput != 0)
                {
                    xRegister += queuedInput;
                    queuedInput = 0;
                }
                else
                {
                    string line = input.Dequeue();
                    queuedInput = line[..4] switch
                    {
                        Add => int.Parse(line.Split(' ')[1]),
                        _ => queuedInput
                    };
                }

                cycle++;
                if ((cycle - 20) % 40 == 0) total += xRegister * cycle;
            }

            return total;
        }
    }
}
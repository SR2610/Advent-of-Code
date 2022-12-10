using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day10
    {
        public static int SolvePartOne(IEnumerable<string> data)
        {
            string[] input = data as string[] ?? data.ToArray();
            int[] checkCycles = new[] {20, 60, 100, 140, 180, 220};
            int cycle = 1;
            int currentLine = 0;
            bool hasInput = true;
            bool busy = false;
            int xRegister = 1;
            int total = 0;
            int queuedInput = 0;
            while (hasInput)
            {
                if (busy)
                {
                    busy = false;
                    xRegister += queuedInput;
                    queuedInput = 0;
                }
                else
                {
                    if (currentLine < input.Count())
                    {
                        switch (input[currentLine].Substring(0,4))
                        {
                            case "noop": break;
                            case "addx":
                            {
                                queuedInput=int.Parse(input[currentLine].Split(' ')[1]);
                                busy = true;
                                break;
                            }
                        }

                        currentLine++;
                    }
                    else
                    {
                        hasInput = false;
                    }
                }

                cycle++;

                if (checkCycles.Contains(cycle))
                {
                    total += (xRegister * cycle);
                }



            }


            return total;
        }


        public static int SolvePartTwo(IEnumerable<string> data)
        {
            string[] input = data as string[] ?? data.ToArray();
            int[] checkCycles = new[] {20, 60, 100, 140, 180, 220};
            int cycle = 1;
            int currentLine = 0;
            bool hasInput = true;
            bool busy = false;
            int xRegister = 1;
            int total = 0;
            int queuedInput = 0;
            int currentPixel = 0;
            while (hasInput)
            {
                
                int spritePosition = xRegister;
                if (MathF.Abs((currentPixel) - spritePosition) <= 1)
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }

                currentPixel++;
                if (currentPixel == 40)
                {
                    Console.WriteLine();
                    currentPixel = 0;
                }
                
                if (busy)
                {
                    busy = false;
                    xRegister += queuedInput;
                    queuedInput = 0;
                }
                else
                {
                    if (currentLine < input.Count())
                    {
                        switch (input[currentLine].Substring(0,4))
                        {
                            case "noop": break;
                            case "addx":
                            {
                                queuedInput=int.Parse(input[currentLine].Split(' ')[1]);
                                busy = true;
                                break;
                            }
                        }

                        currentLine++;
                    }
                    else
                    {
                        hasInput = false;
                    }
                }
                
                cycle++;


            }


            return total;
        }
    }
}
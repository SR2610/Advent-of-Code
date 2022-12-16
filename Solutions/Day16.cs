using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day16
	{
		private static void Parse(string[] input, out int start, out List<int[]> graph, out List<int> flows)
		{
			List<(string valveName, int flowRate, string[] connections)> valves = new List<(string, int, string[])>();
			graph = new List<int[]>();
			flows = new List<int>();
			foreach (string line in input)
			{
				string[] split = line.Split(';');

				string valve = split[0].Substring(6, 2);
				int flowRate = int.Parse(split[0].Split('=')[1]);
				string[] connectedValves = split[1].Split(new[] {"valves ", "valve "}, StringSplitOptions.RemoveEmptyEntries)[1].Split(", ");
				valves.Add((valve, flowRate, connectedValves));
			}

			valves = valves.OrderByDescending(valve => valve.flowRate).ToList();


			Dictionary<string, int> labelMap = new Dictionary<string, int>();


			foreach ((string label, int flow, string[] _) in valves)
			{
				labelMap[label] = labelMap.Count;
				flows.Add(flow);
			}


			foreach ((string _, int _, string[] connections) in valves)
			{
				graph.Add(connections.Select(s => labelMap[s]).ToArray());
			}

			start = labelMap["AA"];
		}

		public static int SolvePartOne(string[] input)
		{
			Parse(input, out int start, out List<int[]> graph, out List<int> flows);

			List<(int, int, int, int)> states = new List<(int, int, int, int)> {(start, 0, 0, 0)};

			int[] best = new int[4194304];

			int optimalPressureReleased = 0;

			for (int minute = 1; minute <= 29; minute++)
			{
				List<(int, int, int, int)> nstates = new List<(int, int, int, int)>();
				foreach ((int n, int bits, int flow, int acc) in states)
				{
					int code = (n << 16) + bits;
					int projected = acc + flow * (30 - minute + 1);
					if (best[code] > projected + 1)
					{
						continue;
					}

					// open valve
					if (flows[n] > 0 && (bits & (1 << n)) == 0)
					{
						int nbits = bits | (1 << n);
						int nflow = flow + flows[n];
						code = (n << 16) + nbits;
						projected = acc + flow + nflow * (30 - minute);
						if (projected + 1 > best[code])
						{
							nstates.Add((n, nbits, nflow, acc + flow));
							best[code] = projected + 1;
							if (projected > optimalPressureReleased)
								optimalPressureReleased = projected;
						}
					}

					foreach (int dst in graph[n])
					{
						code = (dst << 16) + bits;
						projected = acc + flow * (30 - minute + 1);
						if (projected + 1 > best[code])
						{
							nstates.Add((dst, bits, flow, acc + flow));
							best[code] = projected + 1;
							if (projected > optimalPressureReleased) 
								optimalPressureReleased = projected;
						}
					}
				}

				states = nstates;
			}

			return optimalPressureReleased;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day16
	{
		private static void SetupInput(string[] input, out int start, out List<int[]> graph, out List<int> flows)
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
			SetupInput(input, out int start, out List<int[]> valves, out List<int> flowMap);

			List<(int, int, int, int)> states = new List<(int, int, int, int)> {(start, 0, 0, 0)}; //Create initial state from AA with no values

			int[] best = new int[5000000]; //Create empty int array for storing the best options

			int optimalPressureReleased = int.MinValue; //Set really bad first optimal pressure

			for (int minute = 1; minute <= 29; minute++) //Go through all 30 minutes before the volcano goes
			{
				List<(int, int, int, int)> newStates = new List<(int, int, int, int)>();
				foreach ((int valve, int bits, int flow, int acc) in states)
				{
					int index = (valve << 16) + bits;
					
					int projected = acc + flow * (30 - minute + 1); //Check how much opening this valve would add
					
					if (best[index] > projected + 1) //If this wouldn't be better, skip it
					{
						continue;
					}

					if (flowMap[valve] > 0 && (bits & (1 << valve)) == 0) //Check that this makes flow and that it isn't open already
					{
						int newBits = bits | (1 << valve);
						int newFlow = flow + flowMap[valve];
						index = (valve << 16) + newBits;
						projected = acc + flow + newFlow * (30 - minute); //Calculate what this states flow will be for the remainder of the time
						if (projected + 1 > best[index]) //If its better than the current best option for this state
						{
							newStates.Add((valve, newBits, newFlow, acc + flow)); //Add the new state that we can check off of this
							best[index] = projected + 1;  //Add the best value 
							if (projected > optimalPressureReleased)
								optimalPressureReleased = projected;
						}
					}

					foreach (int destination in valves[valve]) //Check all the valves
					{
						index = (destination << 16) + bits;
						projected = acc + flow * (30 - minute + 1); //Calculate the flow
						if (projected + 1 > best[index])
						{
							newStates.Add((destination, bits, flow, acc + flow));
							best[index] = projected + 1;
							if (projected > optimalPressureReleased)
								optimalPressureReleased = projected;
						}
					}
				}

				states = newStates; //Update the states to the new point to work from
			}

			return optimalPressureReleased;
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public class Day16
	{

		public static int SolvePartOne(string[] input)
		{
			//parse input into valves and connections
			//Timer remaining minutes int 30
			Valve startingPoint;
			List<Valve> valves = new List<Valve>();
			int minutesRemaining = 30;
			var connections = new Dictionary<string, string[]>();

			foreach (string line in input)
			{
				string[] split = line.Split(';');

				string valve = split[0].Substring(6, 2);
				int flowRate = int.Parse(split[0].Split('=')[1]);
				string[] sep = new[] {"valves ","valve "};
				var connectedValves = split[1].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1].Split(',');

				Valve v = new Valve(valve, flowRate);
				if (valve == "AA")
					startingPoint = v;
				connections.Add(valve,connectedValves);
			}
			foreach (var valve in valves)
			{
				valve.DirectConnections.AddRange(valves.Where(v => connections[valve.Name].Contains(v.Name)));
			}
			
			//Solve

			return 0;
		}


		private class Valve
		{
			public string Name { get; }

			public int FlowRate { get; }

			public List<Valve> DirectConnections { get; }

			public List<(Valve Valve, int Cost)> WorkingValves { get; }

			public Valve(string name, int flowRate)
			{
				Name = name;

				FlowRate = flowRate;

				DirectConnections = new List<Valve>();

				WorkingValves = new List<(Valve Valve, int Cost)>();
			}
		}
		
		
	}
}
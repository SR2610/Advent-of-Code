using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day2
	{
		private const int WinScore = 6;
		private const int DrawScore = 3;
		private const int LoseScore = 0;


		private static readonly Dictionary<char, Hand> HandMap = new Dictionary<char, Hand>
		{
			{'A', Hand.ROCK}, {'B', Hand.PAPER}, {'C', Hand.SCISSORS},
			{'X', Hand.ROCK}, {'Y', Hand.PAPER}, {'Z', Hand.SCISSORS}
		};

		//1 <2 < 3 
		public static int SolvePartOne(IEnumerable<string> data)
		{
			return data.Sum(game =>
			{
				HandMap.TryGetValue(game[0], out Hand opponentHand);
				{
					HandMap.TryGetValue(game[2], out Hand playerHand);

					return GetScoreFromOutcome(opponentHand, playerHand) + (int) playerHand;
				}
			});
		}

		public static int SolvePartTwo(IEnumerable<string> data)
		{
			return data.Sum(game =>
			{
				HandMap.TryGetValue(game[0], out Hand opponentHand);
				Hand targetHand = GetHandForTarget(opponentHand, game[2]);
				return GetScoreFromOutcome(opponentHand, targetHand) + (int) targetHand;
			});
		}


		private static int GetScoreFromOutcome(Hand c, Hand c1)
		{
			if (c == c1)
			{
				return DrawScore;
			}

			return c switch
			       {
				       Hand.ROCK => c1 == Hand.PAPER ? WinScore : LoseScore,
				       Hand.PAPER => c1 == Hand.SCISSORS ? WinScore : LoseScore,
				       Hand.SCISSORS => c1 == Hand.ROCK ? WinScore : LoseScore,
				       _ => 0
			       };
		}


		private static Hand GetHandForTarget(Hand toBeat, char targetOutcome)
		{
			return targetOutcome switch
			       {
				       'Z' => toBeat switch
				              {
					              Hand.ROCK => Hand.PAPER,
					              Hand.PAPER => Hand.SCISSORS,
					              _ => Hand.ROCK
				              },
				       'X' => toBeat switch
				              {
					              Hand.ROCK => Hand.SCISSORS,
					              Hand.PAPER => Hand.ROCK,
					              _ => Hand.PAPER
				              },
				       _ => toBeat
			       };
		}

		private enum Hand
		{
			ROCK = 1,
			PAPER = 2,
			SCISSORS = 3
		}
	}
}
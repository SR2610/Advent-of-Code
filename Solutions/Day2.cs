using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace Advent_2022.Solutions
{
	public class Day2
	{
		private const int ROCK_SCORE = 1; //AX
		private const int PAPER_SCORE = 2; //BY
		private const int SCISSORS_SCORE = 3; //CZ

		private const int WIN_SCORE = 6;
		private const int DRAW_SCORE = 3;
		private const int LOSE_SCORE = 0;
		
		
		//1 <2 < 3 
		public static int SolvePartOne(IEnumerable<string> data)
		{
			return data.Sum(game => GetScoreFromOutcome(ConvertToHand(game[0]), ConvertToHand(game[2])) + GetScoreFromHand(ConvertToHand(game[2])));
		}
		
		public static int SolvePartTwo(IEnumerable<string> data)
		{
			return data.Sum(game =>
			{
				char opponentHand = ConvertToHand(game[0]);
				char targetHand = GetHandForTarget(opponentHand, game[2]);
				return GetScoreFromOutcome(opponentHand, targetHand) + GetScoreFromHand(targetHand);
				
			});
		}

		
		
		private static char ConvertToHand(char input)
		{
			switch (input)
			{
				case'A' :case'X': return 'R';
				case'B' :case'Y': return 'P';
				default: return 'S';
			}
		}

		private static int GetScoreFromOutcome(char c, char c1)
		{
			if (c==c1)
			{
				return DRAW_SCORE;
			}

			switch (c)
			{
				case 'R': return c1=='P'? WIN_SCORE : LOSE_SCORE;
				case 'P': return c1=='S'? WIN_SCORE : LOSE_SCORE;;
				case 'S': return c1=='R'? WIN_SCORE : LOSE_SCORE;;
			}
			
			
			return 0;
		}



		private static char GetHandForTarget(char toBeat,char targetOutcome)
		{
			return targetOutcome switch
			       {
				       'Z' => toBeat switch
				              {
					              'R' => 'P',
					              'P' => 'S',
					              _ => 'R'
				              },
				       'X' => toBeat switch
				              {
					              'R' => 'S',
					              'P' => 'R',
					              _ => 'P'
				              },
				       _ => toBeat
			       };
		}
	

		private static int GetScoreFromHand(char hand)
		{
			return hand switch
			       {
				       'R' => ROCK_SCORE,
				       'P' => PAPER_SCORE,
				       'S' => SCISSORS_SCORE,
				       _ => 0
			       };
		}
	}
}
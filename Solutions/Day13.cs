using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day13
	{
		public static int SolvePartOne(string[] data)
		{
			int total = 0;
			for (int i = 0; i < data.Length; i += 3)
			{
				Item left = Parse(data[i]);
				Item right = Parse(data[i + 1]);

				if (Compare(left, right) == Comparison.SMALLER) //If left is smaller than right
				{
					total += i / 3 + 1;
				}
			}

			return total;
		}

		public static int SolvePartTwo(IEnumerable<string> data)
		{
			List<Item> items = (from line in data where line.Length > 0 select Parse(line)).ToList(); //Parse all lines

			//Create divider packets
			Item a = Parse("[[2]]");
			Item b = Parse("[[6]]");

			items.Add(a);
			items.Add(b);

			items.Sort(DoComparisonForSort);
			return (items.IndexOf(a) + 1) * (items.IndexOf(b) + 1);
		}


		private static Item Parse(string input)
		{
			List<Item> items = new List<Item>();

			for (int inputIndex = 0; inputIndex < input.Length;)
			{
				char currentCharacter = input[inputIndex];
				if (currentCharacter == '[')
				{
					int arrayIndex = inputIndex;
					int arrayLength = 0;
					int depth = 1;
					inputIndex++;
					while (depth > 0) //Go until all open brackets are closed
					{
						currentCharacter = input[inputIndex++];
						switch (currentCharacter)
						{
							case '[':
								depth++;
								break;
							case ']':
								depth--;
								break;
						}

						arrayLength++;
					}

					items.Add(Parse(input.Substring(arrayIndex + 1, arrayLength - 1))); //Parse the content of the array

					inputIndex++;
				}
				else
				{
					int intStringIndex = inputIndex;
					int intStringLength = 0;

					while (inputIndex < input.Length && char.IsDigit(input[inputIndex++])) //Find the number in the list
					{
						intStringLength++;
					}

					if (intStringLength > 0)
					{
						items.Add(new IntItem
						{
							Value = int.Parse(input.Substring(intStringIndex, intStringLength)) //Parse the int
						});
					}
				}
			}


			return new ArrayItem
			{
				Value = items
			};
		}


		private static int DoComparisonForSort(Item left, Item right)
		{
			return (int) Compare(left, right);
		}

		private static Comparison Compare(Item left, Item right)
		{
			if (left.GetType() == typeof(IntItem) && right.GetType() == typeof(IntItem)) //If both sides are whole items, we can check them
			{
				if (((IntItem) left).Value == ((IntItem) right).Value)
				{
					return Comparison.EQUAL;
				}

				return ((IntItem) left).Value < ((IntItem) right).Value ? Comparison.SMALLER : Comparison.BIGGER;
			}

			//Not whole items on both sides

			if (!(left is ArrayItem leftArray)) //If it is not already an array, make it one
			{
				leftArray = new ArrayItem
				{
					Value = new List<Item> {left}
				};
			}

			if (!(right is ArrayItem rightArray))
			{
				rightArray = new ArrayItem
				{
					Value = new List<Item> {right}
				};
			}


			for (int index = 0; index < leftArray.Value.Count; index++)
			{
				if (index >= rightArray.Value.Count()) //If the left is out of items, this is wrong
				{
					return Comparison.BIGGER;
				}

				Comparison comparison = Compare(leftArray.Value[index], rightArray.Value[index]); //Check if left > or < right

				if (comparison == Comparison.EQUAL) //If they were equal, go to the next item in the list
				{
					continue;
				}

				return comparison; //Return < > check
			}


			return leftArray.Value.Count == rightArray.Value.Count ? Comparison.EQUAL : Comparison.SMALLER;
		}

		private enum Comparison
		{
			BIGGER = 1,
			EQUAL = 0,
			SMALLER = -1
		}

		private abstract class Item
		{
		}

		private class IntItem : Item
		{
			public int Value { get; set; }
		}

		private class ArrayItem : Item
		{
			public List<Item> Value { get; set; }
		}
	}
}
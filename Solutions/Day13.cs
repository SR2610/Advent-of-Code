using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day13
	{
		public static int SolvePartOne(string[] data)
		{
			int total = 0;
			int pairId = 1;
			for (int i = 0; i < data.Length; i += 3)
			{
				Item left = Parse(data[i]);
				Item right = Parse(data[i + 1]);

				if (Compare(left, right) == -1)
				{
					total += pairId;
				}

				pairId++;
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

			items.Sort(Compare);

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


		private static int Compare(Item left, Item right)
		{
			if (left.GetType() == typeof(IntItem) && right.GetType() == typeof(IntItem))
			{
				if (((IntItem) left).Value == ((IntItem) right).Value)
				{
					return 0;
				}

				if (((IntItem) left).Value < ((IntItem) right).Value)
				{
					return -1;
				}

				return 1;
			}

			if (!(left is ArrayItem leftArray))
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
				if (index >= rightArray.Value.Count())
				{
					return 1;
				}

				int comparison = Compare(leftArray.Value[index], rightArray.Value[index]);
				if (comparison == 0)
				{
					continue;
				}

				return comparison;
			}


			if (leftArray.Value.Count() == rightArray.Value.Count())
			{
				return 0;
			}

			return -1;
		}
	}


	public abstract class Item
	{
	}

	public class IntItem : Item
	{
		public int Value { get; set; }
	}

	public class ArrayItem : Item
	{
		public List<Item> Value { get; set; }
	}
}
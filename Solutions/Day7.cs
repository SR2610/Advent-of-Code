using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day7
	{
		private static DiskContent Root;

		private static void SetupFileSystem(IEnumerable<string> data)
		{
			Root = new DiskContent(-1, null, "/");
			DiskContent currentDirectory = null;

			foreach (string command in data)
			{
				string[] splitCommand = command.Split();

				switch (splitCommand[0])
				{
					case "$":

						currentDirectory = splitCommand[1] switch
						                   {
							                   "cd" => splitCommand[2] switch
							                           {
								                           ".." => currentDirectory?.parent,
								                           "/" => Root,
								                           _ => currentDirectory?.EnterDirectory(splitCommand[2])
							                           },
							                   _ => currentDirectory
						                   };
						break;
					case "dir":
						currentDirectory?.AddContent(-1, splitCommand[1] + " (dir)");
						break;
					default:
						currentDirectory?.AddContent(int.Parse(splitCommand[0]), splitCommand[1]+(" (file, size="+splitCommand[0]+")"));
						break;
				}
			}
		}


		private static void PrintOutFolder(DiskContent folder,int depth)
		{
			Console.WriteLine(string.Concat(Enumerable.Repeat(" ", depth))+"-" + folder.contentName);
			foreach (DiskContent content in folder.content)
			{
				if (content.fileSize == -1)
				{
					PrintOutFolder(content,depth+1);
				}
				else
				{
					Console.WriteLine(string.Concat(Enumerable.Repeat(" ", depth+1))+"-" + content.contentName);
				}
			}
		}

		public static int SolvePartOne(IEnumerable<string> data)
		{
			SetupFileSystem(data);

			int total = Root.GetAllSubDirectories().Where(folder => folder.GetSize() < 100000).Sum(folder => folder.GetSize());
			
			return total;
		}

		public static int SolvePartTwo(IEnumerable<string> data)
		{
			SetupFileSystem(data);
			int needToDelete = 30000000 - (70000000 - Root.GetSize());

			int smallestPossibleDirectorySize = int.MaxValue;

			foreach (int size in Root.GetAllSubDirectories().Select(dir => dir.GetSize()).Where(size => size > needToDelete && size < smallestPossibleDirectorySize))
			{
				smallestPossibleDirectorySize = size;
			}

			return smallestPossibleDirectorySize;
		}
	}
	
	public class DiskContent
	{
		public readonly List<DiskContent> content = new List<DiskContent>();

		public readonly string contentName;

		public readonly int fileSize;
		public readonly DiskContent parent;

		public DiskContent(int size, DiskContent parentContent, string contentName)
		{
			fileSize = size;
			parent = parentContent;
			this.contentName = contentName;
		}

		public int GetSize()
		{
			return fileSize == -1 ? content.Sum(c => c.GetSize()) : fileSize;
		}

		public DiskContent EnterDirectory(string name)
		{
			return content.First(c => c.contentName.Substring(0,name.Length) == name);
		}


		public void AddContent(int size, string name)
		{
			if (content.All(c => c.contentName != name))
			{
				content.Add(new DiskContent(size, this, name));
			}
		}


		public IEnumerable<DiskContent> GetAllSubDirectories()
		{
			List<DiskContent> allFolders = new List<DiskContent> {this};
			foreach (DiskContent contentItem in content.Where(contentItem => contentItem.fileSize == -1))
			{
				allFolders.AddRange(contentItem.GetAllSubDirectories());
			}

			return allFolders;
		}
	}
}
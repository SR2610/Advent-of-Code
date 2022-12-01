using System.Collections.Generic;
using System.IO;

public static class Utils
{
	public static string GetDataFromFile(string fileName, bool isTest = false)
	{
		return File.ReadAllText("../../../Data" + (isTest ? "/Test/" : "/") + fileName);
	}

	public static IEnumerable<string> GetDataFromFileAsLines(string fileName, bool isTest = false)
	{
		return File.ReadAllLines("../../../Data" + (isTest ? "/Test/" : "/") + fileName);
	}
}
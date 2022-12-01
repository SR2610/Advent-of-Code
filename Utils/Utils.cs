
	public static class Utils
	{

		public static string GetDataFromFile(string fileName, bool isTest =false)
		{
			return System.IO.File.ReadAllText("../../../Data"+(isTest?"/Test/":"/")+fileName);
		}
		
		public static string[] GetDataFromFileAsLines(string fileName, bool isTest = false)
		{
			return System.IO.File.ReadAllLines("../../../Data"+(isTest?"/Test/":"/")+fileName);
		}
		
	}

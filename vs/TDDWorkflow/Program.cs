using System;
using System.IO;
using LiongStudio.ComputerVision.Tdd;

namespace TDDExtractor
{
	class Program
	{
		static MatlabDelegate _Matlab = new MatlabDelegate();

		static int Main(string[] args)
		{
			var error = false;

			foreach (var filePath in args)
			{
				var fileDir = Path.GetDirectoryName(filePath);
				var fileName = Path.GetFileNameWithoutExtension(filePath);
				var fileExt = Path.GetExtension(filePath);
				Console.WriteLine("Extracting TDD Feature for " + fileName + "...");

				if (!File.Exists(filePath)) { Console.WriteLine("File\"" + fileName + "\" does not exist!"); error = true; }

				try { _Matlab.ExtractTddFeature(AppDomain.CurrentDomain.BaseDirectory, fileDir, fileName, fileDir, 3, 0); }
				catch (Exception) { error = true; }
				if (!error) Console.WriteLine("Finished " + fileName + '.');
				else Console.WriteLine("Some error occured executing " + fileName + '.');
			}
			_Matlab.Dispose();
			
			Console.WriteLine("All done.");

			return error ? 1 : 0;
		}
	}
}

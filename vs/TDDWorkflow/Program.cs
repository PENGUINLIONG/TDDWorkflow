using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System.IO;
using System.Diagnostics;

namespace TDDExtractor
{
	class Program
	{
		static int Main(string[] args)
		{
			var tdd = new TddMatlabHelper.Tdd();
			var error = false;

			foreach (var filePath in args)
			{
				var fileDir = Path.GetDirectoryName(filePath);
				var fileName = Path.GetFileNameWithoutExtension(filePath);
				var fileExt = Path.GetExtension(filePath);
				Console.WriteLine("Extracting TDD Feature for " + fileName + "...");

				if (!File.Exists(filePath)) { Console.WriteLine("File\"" + fileName + "\" does not exist!"); error = true; }

				try { tdd.ExtractTddFeature(AppDomain.CurrentDomain.BaseDirectory, fileDir, fileName, fileDir, 3, 0); }
				catch (Exception) { error = true; }
				if (!error) Console.WriteLine("Finished " + fileName + '.');
				else Console.WriteLine("Some error occured executing " + fileName + '.');
			}
			tdd.Dispose();
			
			Console.WriteLine("All done.");

			return error ? 1 : 0;
		}
	}
}

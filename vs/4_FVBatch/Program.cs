using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using LiongStudio.ComputerVision.Utils;

namespace FVBatch
{
	class Program
	{
		static void Main(string[] args)
		{
			var searchDepth = 5;
			Console.WriteLine("Batch work started, {0} batches will be despatched.", args.Length);
			foreach (var dir in args)
			{
				if (!Directory.Exists(dir)) { Console.WriteLine("Directory \"" + dir + "\" does not exist."); continue; }

				var files = FileLocator.FindAllAvi(dir, searchDepth);

				Console.WriteLine("Despatching work for {0} files in directory \"{1}\" (search depth = {2}).", files.Count, dir, searchDepth);
				SubprocedureLauncher.LaunchFor(AppDomain.CurrentDomain.BaseDirectory + "FVWorkflow.exe", files);
			}

			Console.WriteLine("All batches are finished.");
			Console.ReadKey(true);
		}
	}
}

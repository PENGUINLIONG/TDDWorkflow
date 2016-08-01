using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using LiongStudio.ComputerVision.Utils;

namespace CVBatchAvi
{
	class Program
	{
		static int refCount = 0;
		static void IncreaseRefCount() { ++refCount; }
		static void DecreaseRefCount() { if (--refCount <= 0) ShowExitPrompt(); }

		static void RunWorkflow(string dir, List<string> aviPaths)
		{
			SubprocedureLauncher.LaunchFor(AppDomain.CurrentDomain.BaseDirectory + "PreWorkflow.exe", aviPaths);
			DecreaseRefCount();
		}

		static async void RunWorkflowAsync(string dir, List<string> aviPaths)
		{
			await Task.Run(() => { RunWorkflow(dir, aviPaths); });
		}

		static void ShowExitPrompt() { Console.WriteLine("All batches are finished."); }

		static void Main(string[] args)
		{
			var searchDepth = 5;
			Console.WriteLine("Batch work started, {0} batches will be despatched.", args.Length);
			foreach(var dir in args)
			{
				if (!Directory.Exists(dir)) { Console.WriteLine("Directory \"" + dir + "\" does not exist."); continue; }

				Console.WriteLine("Despatching work for \"" + dir + "\".");
				IncreaseRefCount();
				RunWorkflowAsync(dir, FileLocator.FindAllAvi(dir, searchDepth));
			}
			while (refCount > 0) Console.ReadKey(true);
		}
	}
}

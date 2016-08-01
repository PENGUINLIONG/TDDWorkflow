using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CVBatchAvi
{
	class Program
	{
		static int refCount = 0;
		static void IncreaseRefCount() { ++refCount; }
		static void DecreaseRefCount() { if (--refCount <= 0) ShowExitPrompt(); }

		static List<string> FindAllAvi(string dir, int depth)
		{
			List<string> rv = new List<string>();
			if (depth <= 0) return rv;
			
			foreach (var file in Directory.GetFiles(dir))
				if ((!Path.GetFileName(file).StartsWith("K_")) && (Path.GetExtension(file) == ".avi"))
					rv.Add('\"' + file + '\"');
			foreach (var subdir in Directory.GetDirectories(dir)) rv.AddRange(FindAllAvi(subdir, depth - 1));

			return rv;
		}

		static void RunWorkflow(string dir, List<string> aviPaths)
		{
			var sw = Stopwatch.StartNew();
			var wf = new Process();

			try
			{
				wf.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "CVWorkflow.exe";
				wf.StartInfo.Arguments = string.Join(" ", aviPaths);
				wf.StartInfo.CreateNoWindow = true;
				wf.StartInfo.UseShellExecute = false;
				wf.Start();
				wf.WaitForExit();
			}
			catch (Exception e)
			{
				Console.WriteLine("======= Exception occured =======");
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
			sw.Stop();
			if (wf.ExitCode == 0)
				Console.WriteLine("Finished a batch of " + aviPaths.Count + " files. Time elapsed: " + sw.ElapsedMilliseconds + "ms.");
			else
				Console.WriteLine("Some implicit error occured in DF/IT execution for directory \"" + dir + "\".");

			DecreaseRefCount();
		}

		static async void RunWorkflowAsync(string dir, List<string> aviPaths)
		{
			await Task.Run(() => { RunWorkflow(dir, aviPaths); });
		}

		static void ShowExitPrompt() { Console.WriteLine("All batches are finished."); }

		static void Main(string[] args)
		{
			Console.WriteLine("Batch work started, {0} batches will be despatched.", args.Length);
			foreach(var dir in args)
			{
				if (!Directory.Exists(dir)) { Console.WriteLine("Directory \"" + dir + "\" does not exist."); continue; }

				Console.WriteLine("Despatching work for \"" + dir + "\".");
				IncreaseRefCount();
				RunWorkflowAsync(dir, FindAllAvi(dir, 5));
			}
			while (refCount > 0) Console.ReadKey(true);
		}
	}
}

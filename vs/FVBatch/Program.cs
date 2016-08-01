using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FVBatch
{
	class Program
	{
		static List<string> FindAllAvi(string dir, int depth)
		{
			List<string> rv = new List<string>();
			if (depth <= 0) return rv;

			foreach (var file in Directory.GetFiles(dir)) if ((!Path.GetFileName(file).StartsWith("K_")) && Path.GetExtension(file) == ".avi") rv.Add('\"' + file + '\"');
			foreach (var subdir in Directory.GetDirectories(dir)) rv.AddRange(FindAllAvi(subdir, depth - 1));

			return rv;
		}

		static void ExtractFisherVector(List<string> aviPaths)
		{
			long count = 0;
			foreach (var file in aviPaths)
			{
				var sw = Stopwatch.StartNew();
				var wf = new Process();

				try
				{
					wf.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "FVWorkflow.exe";
					wf.StartInfo.Arguments = file;
					wf.StartInfo.CreateNoWindow = true;
					wf.StartInfo.UseShellExecute = false;
					wf.Start();
					wf.WaitForExit();
				}
				catch (Exception e)
				{
					Console.WriteLine("======= Exception occured =======");
					Console.WriteLine(file);
					Console.WriteLine(e.Message);
					Console.WriteLine(e.StackTrace);
				}
				sw.Stop();
				++count;

				if (wf.ExitCode == 0)
					Console.WriteLine("Finished the #" + count + " out of " + aviPaths.Count + " file(s). Time elapsed: " + sw.ElapsedMilliseconds + "ms.");
				else
					Console.WriteLine("Some Error occured during the execution for file \"" + file + "\".");
			}
		}

		static void Main(string[] args)
		{
			var searchDepth = 5;
			Console.WriteLine("Batch work started, {0} batches will be despatched.", args.Length);
			foreach (var dir in args)
			{
				if (!Directory.Exists(dir)) { Console.WriteLine("Directory \"" + dir + "\" does not exist."); continue; }

				var files = FindAllAvi(dir, searchDepth);

				Console.WriteLine("Despatching work for {0} files in directory \"{1}\" (search depth = {2}).", files.Count, dir, searchDepth);
				ExtractFisherVector(files);
			}

			Console.WriteLine("All batches are finished.");
			Console.ReadKey(true);
		}
	}
}

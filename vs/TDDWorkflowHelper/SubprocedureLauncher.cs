using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiongStudio.ComputerVision.Utils
{
	public static class SubprocedureLauncher
	{
		/// <summary>
		/// Lauch a subprocedure with no promt window.
		/// </summary>
		/// <param name="subprocedure">Path to the executable to be launched.</param>
		/// <param name="args">Arguments to be passed.</param>
		/// <returns>The time elapsed in previous execution, in milliseconds. If the process failed or exceptions had occured, a negative time will be returned.</returns>
		private static long LaunchProcess(string subprocedure, string args)
		{
			Process process = null;
			var sw = Stopwatch.StartNew();
			try
			{
				var info = new ProcessStartInfo { FileName = subprocedure, Arguments = args, CreateNoWindow = true, UseShellExecute = false };
				process = Process.Start(info);
				process.WaitForExit();
			}
			catch (Exception e)
			{
				Console.WriteLine("======= Exception occured =======");
				Console.WriteLine(e.ToString());
			}
			sw.Stop();

			return (process != null && process.ExitCode == 0) ? sw.ElapsedMilliseconds : -sw.ElapsedMilliseconds; 
		}

		/// <summary>
		/// Lauch subprocedure for all targets in a single batch.
		/// This method could be efficient as it only starts up one process and avoids loading MCR for multiple times. When an error occurs, however, the subprocedure will abort.
		/// </summary>
		/// <param name="subprocedure">Path to the executable to be launched.</param>
		/// <param name="targets">Path to target files to be processed by <paramref name="subprocedure"/>.</param>
		/// <returns></returns>
		private static void LaunchInBatch(string subprocedure, List<string> targets)
		{
			var time = LaunchProcess(subprocedure, string.Join(" ", targets));
			if (time > 0)
				Console.WriteLine("Finished a batch of " + targets.Count + " target(s). Time elapsed: " + time + "ms.");
			else
				Console.WriteLine("Some error occured during execution. Time elapsed: " + -time + "ms.");
		}

		/// <summary>
		/// Launch subprocedure for all targets one-by-one.
		/// This method could be inefficient as it start processes for all targets and MCR is loaded for multiple times. But when error occurs in a single file, the entire procedure will not be interupted.
		/// </summary>
		/// <param name="subprocedure">Path to the executable to be launched.</param>
		/// <param name="targets">Path to target files to be processed by <paramref name="subprocedure"/>.</param>
		private static void LaunchForEach(string subprocedure, List<string> targets)
		{
			long count = 0;
			foreach (var target in targets)
			{
				var time = LaunchProcess(subprocedure, target);

				++count;
				if (time > 0)
					Console.WriteLine("Finished the #" + count + " out of " + targets.Count + " target(s). Time elapsed: " + time + "ms.");
				else
					Console.WriteLine("Some error occured during the execution for file \"" + target + "\". Time elapsed: " + -time + "ms.");
			}
		}

		/// <summary>
		/// Launch subprocedure.
		/// </summary>
		/// <param name="subprocedure">Path to the executable to be launched.</param>
		/// <param name="targets">Path to target files to be processed by <paramref name="subprocedure"/>.</param>
		/// <param name="launchForAllTargets">Determines if target should be processed in a single batch.</param>
		public static void LaunchFor(string subprocedure, List<string> targets, bool launchForAllTargets = true)
		{
			if (launchForAllTargets) LaunchInBatch(subprocedure, targets);
			else LaunchForEach(subprocedure, targets);
		}
	}
}

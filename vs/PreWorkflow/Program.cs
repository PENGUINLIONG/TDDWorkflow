using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CVWorkflow
{
	class Program
	{
		static StreamWriter _Log;

		static void RunDenseFlow(string inputFilePath, string outputFilePrefix)
		{
			var dfStopwatch = Stopwatch.StartNew();
			var dfProcess = new Process();
			try
			{
				dfProcess.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"dense_flow.exe";
				dfProcess.StartInfo.Arguments =
					string.Format("-f \"{0}\" -i \"{1}\" -x \"{2}\" -y \"{3}\" -b 20",
					inputFilePath, outputFilePrefix + "_i", outputFilePrefix + "_x", outputFilePrefix + "_y");
				dfProcess.StartInfo.CreateNoWindow = true;
				dfProcess.StartInfo.UseShellExecute = false;
				dfProcess.Start();
				dfProcess.WaitForExit();
			}
			catch (Exception e)
			{
				_Log.WriteLine("======= Exception occured =======");
				_Log.WriteLine(e.Message);
				_Log.WriteLine(e.StackTrace);
			}
			dfStopwatch.Stop();
			if (dfProcess.ExitCode == 0)
				_Log.WriteLine("DF for file \"" + inputFilePath + "\" done! Time elapsed: " + dfStopwatch.ElapsedMilliseconds + "ms.");
			else
				_Log.WriteLine("Some implicit error occured in DF execution for file \"" + inputFilePath + "\".");
		}

		static void RunImprovedTrajectory(string inputFilePath, string idtFilePath, string trajectoryFilePath)
		{
			var itStopwatch = Stopwatch.StartNew();
			var itProcess = new Process();
			try
			{
				itProcess.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"improved_trajectory.exe";
				itProcess.StartInfo.Arguments = string.Format("-f \"{0}\" -o \"{1}\" -r \"{2}\"", inputFilePath, idtFilePath, trajectoryFilePath);
				itProcess.StartInfo.CreateNoWindow = true;
				itProcess.StartInfo.UseShellExecute = false;
				itProcess.Start();
				itProcess.WaitForExit();
			}
			catch (Exception e)
			{
				_Log.WriteLine("======= Exception occured =======");
				_Log.WriteLine(e.Message);
				_Log.WriteLine(e.StackTrace);
			}
			itStopwatch.Stop();
			if (itProcess.ExitCode == 0)
				_Log.WriteLine("IT for file \"" + inputFilePath + "\" done! Time elapsed: " + itStopwatch.ElapsedMilliseconds + "ms.");
			else
				_Log.WriteLine("Some implicit error occured in IT execution for file \"" + inputFilePath + "\".");
		}

		static int Main(string[] args)
		{
			var logDir = AppDomain.CurrentDomain.BaseDirectory + @"\Log";
			if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
			_Log = File.CreateText(logDir + @"\CVWorkflow_P" + Process.GetCurrentProcess().Id + ".log");
			_Log.WriteLine("Workflow started.");

			foreach (string path in args)
			{
				var dirName = Path.GetDirectoryName(path) +"\\Result\\";
				var fileName = Path.GetFileNameWithoutExtension(path);
				if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
				if (!File.Exists(path)) { _Log.WriteLine("File \"" + path + "\" does not exist."); continue; }

				_Log.WriteLine("Working on \"" + fileName + "\"...");

				RunDenseFlow(path, dirName + fileName + "_flow");
				RunImprovedTrajectory(path, dirName + fileName + "_idt.bin", dirName + fileName + "_tra.bin");

				_Log.WriteLine("Finished file \"" + fileName + "\".");
				_Log.WriteLine();
				_Log.Flush();
			}
			_Log.WriteLine("Workflow finished.");
			_Log.Close();

			return 0;
		}
	}
}

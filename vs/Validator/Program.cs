using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VideoHelper;

namespace Validator
{
	class Program
	{
		static Video _Video;

		class CVLogger : IDisposable
		{
			StreamWriter _Report;

			public CVLogger()
			{
				var reportDir = AppDomain.CurrentDomain.BaseDirectory + @"\ValidationReport";
				if (!Directory.Exists(reportDir))
					Directory.CreateDirectory(reportDir);

				_Report = File.CreateText(reportDir + @"\Report_" + System.Diagnostics.Process.GetCurrentProcess().Id + ".log");
			}

			public void WriteLine(string str)
			{
				Console.WriteLine(str);
				_Report.WriteLine(str);
			}

			public void Flush()
			{
				_Report.Flush();
			}

			public void Dispose()
			{
				_Report.Dispose();
			}
		}

		static CVLogger _Log;

		static List<string> FindAllAvi(string dir, int depth)
		{
			List<string> rv = new List<string>();
			if (depth <= 0) return rv;

			foreach (var file in Directory.GetFiles(dir)) if ((!Path.GetFileName(file).StartsWith("K_")) && Path.GetExtension(file) == ".avi") rv.Add(file);
			foreach (var subdir in Directory.GetDirectories(dir)) rv.AddRange(FindAllAvi(subdir, depth));

			return rv;
		}
		
		static void CheckDenseFlowImages(string dir, string fileNameNoEx)
		{
			var vidPath = dir + '\\' + fileNameNoEx + ".avi";
			if (!File.Exists(vidPath)) _Log.WriteLine("Failed accessing to file: " + vidPath);

			var count = (_Video.GetVideoFrameCount(vidPath) as MathWorks.MATLAB.NET.Arrays.MWNumericArray).ToScalarInteger();

			int countI = 0, countX = 0, countY = 0;
			foreach (var imgPath in Directory.GetFiles(dir + @"\Result")) if (Path.GetExtension(imgPath) == ".jpg") try
			{
				var currentFileNameNoEx = Path.GetFileNameWithoutExtension(imgPath);
				if (!currentFileNameNoEx.StartsWith(fileNameNoEx))
					continue;
				var idSection = currentFileNameNoEx.Substring(fileNameNoEx.Length + 6 /* <- Length of "_flow_".*/);
				switch (idSection[0])
				{
					case 'i': ++countI; break;
					case 'x': ++countX; break;
					case 'y': ++countY; break;
					default: break;
				}
			}
			catch (Exception) { continue; }
			if (countI != count - 1)
				_Log.WriteLine("Output image counts of flow_i mismatch with frame count.");
			if (countX != count - 1)
				_Log.WriteLine("Output image counts of flow_x mismatch with frame count.");
			if (countY != count - 1)
				_Log.WriteLine("Output image counts of flow_y mismatch with frame count.");
		}

		static void CheckTrajectoryAndIdtBinaries(string dir, string fileNameNoEx)
		{
			string idtPath = dir + @"\Result\" + fileNameNoEx + "_idt.bin";
			string traPath = dir + @"\Result\" + fileNameNoEx + "_tra.bin";
			
			if (!File.Exists(idtPath))
				_Log.WriteLine("IDT binary does not exist.");
			else if (new FileInfo(idtPath).Length < 1024 * 50)
				_Log.WriteLine("Length of IDT binary seems too short (< 50KB)");

			if (!File.Exists(traPath))
				_Log.WriteLine("Trajectory binary does not exist.");
			else if (new FileInfo(traPath).Length < 1024 * 50)
				_Log.WriteLine("Length of trajectory binary seems too short (< 50KB)");
		}

		static void CheckTddMatricies(string dir, string fileNameNoEx)
		{
			string tddPrefix = dir + @"\Result\" + fileNameNoEx;

			if (!File.Exists(tddPrefix + "_scale3_s_c4_n1.mat"))
				_Log.WriteLine("TDD (spatial c4 n1) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c4_n1.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (spatial c4 n1) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_s_c4_n2.mat"))
				_Log.WriteLine("TDD (spatial c4 n2) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c4_n2.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (spatial c4 n2) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_s_c5_n1.mat"))
				_Log.WriteLine("TDD (spatial c5 n1) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c5_n1.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (spatial c5 n1) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_s_c5_n2.mat"))
				_Log.WriteLine("TDD (spatial c5 n2) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c5_n2.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (spatial c5 n2) seems too short (< 50KB)");



			if (!File.Exists(tddPrefix + "_scale3_t_c3_n1.mat"))
				_Log.WriteLine("TDD (temporal c3 n1) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c3_n1.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (temporal c3 n1) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_t_c3_n2.mat"))
				_Log.WriteLine("TDD (temporal c3 n2) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c3_n2.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (temporal c3 n2) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_t_c4_n1.mat"))
				_Log.WriteLine("TDD (temporal c4 n1) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c4_n1.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (temporal c4 n1) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_t_c4_n2.mat"))
				_Log.WriteLine("TDD (temporal c4 n2) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c4_n2.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of TDD (temporal c4 n2) seems too short (< 50KB)");
		}

		static void CheckFisherVectors(string dir, string fileNameNoEx)
		{
			string tddPrefix = dir + @"\Result\" + fileNameNoEx;

			if (!File.Exists(tddPrefix + "_scale3_s_c4_fv.mat"))
				_Log.WriteLine("Fisher Vector (spatial c4) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c4_fv.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of Fisher Vector (spatial c4) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_s_c5_fv.mat"))
				_Log.WriteLine("Fisher Vector (spatial c5) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_s_c5_fv.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of Fisher Vector (spatial c5) seems too short (< 50KB)");



			if (!File.Exists(tddPrefix + "_scale3_t_c3_fv.mat"))
				_Log.WriteLine("Fisher Vector (temporal c3) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c3_fv.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of Fisher Vector (temporal c3) seems too short (< 50KB)");

			if (!File.Exists(tddPrefix + "_scale3_t_c4_fv.mat"))
				_Log.WriteLine("Fisher Vector (temporal c4) do not exist.");
			else if (new FileInfo(tddPrefix + "_scale3_t_c4_fv.mat").Length < 1024 * 50)
				_Log.WriteLine("Length of Fisher Vector (temporal c4) seems too short (< 50KB)");
		}

		static void Main(string[] args)
		{
			_Video = new Video();
			_Log = new CVLogger();

			foreach (var dir in args)
			{
				_Log.WriteLine(">>> Searching in directory: " + dir);
				foreach (var fileName in FindAllAvi(dir, 5))
				{
					_Log.WriteLine(">>> Validating the results of file: " + fileName);

					string dirName = Path.GetDirectoryName(fileName);
					string fileNameNoEx = Path.GetFileNameWithoutExtension(fileName);

					if (!Directory.Exists(dirName + @"\Result"))
					{
						_Log.WriteLine("The 'Result' folder does not exist.");
						continue;
					}

					CheckDenseFlowImages(dirName, fileNameNoEx);
					CheckTrajectoryAndIdtBinaries(dirName, fileNameNoEx);
					CheckTddMatricies(dirName, fileNameNoEx);
					CheckFisherVectors(dirName, fileNameNoEx);
				}
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
			_Video.Dispose();
			_Log.Dispose();
		}
	}
}

using System;
using System.Diagnostics;
using System.IO;
using LiongStudio.ComputerVision.Tdd;

namespace FVWorkflow
{
	class Program
	{
		static MatlabDelegate _Matlab = new MatlabDelegate();
		static string[] _Suffix = new string[]
		{
			"scale3_s_c4_n1", "scale3_s_c4_n2",
			"scale3_s_c5_n1", "scale3_s_c5_n2",
			"scale3_t_c3_n1", "scale3_t_c3_n2",
			"scale3_t_c4_n1", "scale3_t_c4_n2"
		};
		static StreamWriter _Log;

		static string _PcaDir, _GmmDir;

		static void ExtractFor(string file)
		{
			var dir = Path.GetDirectoryName(file) + @"\Result";
			var fileNameNoEx = Path.GetFileNameWithoutExtension(file);
			
			for (int i = 0; i < 8;)
			{
				// The matricies of two norm methods will be concatenated, so both of them should be passed as params.
				var suffix1 = _Suffix[i++];
				var suffix2 = _Suffix[i++];
				var tdd1 = dir + '\\' + fileNameNoEx + '_' + suffix1 + ".mat";
				var tdd2 = dir + '\\' + fileNameNoEx + '_' + suffix2 + ".mat";

				if (!File.Exists(tdd1))
					_Log.WriteLine("File missing: " + tdd1);
				else if (!File.Exists(tdd2))
					_Log.WriteLine("File missing: " + tdd2);
				else
					_Matlab.ExtractFisherVector(_PcaDir + '\\' + suffix1 + ".mat", _PcaDir + '\\' + suffix2 + ".mat",
						_GmmDir + '\\' + suffix1 + ".mat", _GmmDir + '\\' + suffix2 + ".mat",
						dir,
						fileNameNoEx + '_' + suffix1, fileNameNoEx + '_' + suffix2,
						dir);
			}
		}

		static int Main(string[] args)
		{
			var envPath = AppDomain.CurrentDomain.BaseDirectory;
			var logDir = envPath + @"Log";
			_PcaDir = envPath + @"PCA";
			_GmmDir = envPath + @"GMM";

			if (!Directory.Exists(logDir))
				Directory.CreateDirectory(logDir);
			_Log = File.CreateText(logDir + @"\FVWorkflow_" + Process.GetCurrentProcess().Id + ".log");
			
			foreach (var file in args)
			{
				_Log.WriteLine("Working on file: " + file);
				if (!File.Exists(file)) { _Log.WriteLine("File does not exist!"); continue; }

				ExtractFor(file);
				/* MAGIC NUMBER, DO NOT REMOVE THIS LINE! */
				/* If this line is removed, the program will exit abnormally with code 'Access Violation' frequently. */
				System.Threading.Thread.Sleep(200);
				_Log.Flush();
			}
			_Log.WriteLine("All done.");
			_Log.Close();
			_Matlab.Dispose();
			return 0;
		}
	}
}

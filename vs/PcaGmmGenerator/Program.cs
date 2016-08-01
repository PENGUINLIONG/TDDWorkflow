using System;
using System.Collections.Generic;
using System.IO;
using LiongStudio.ComputerVision.Tdd;

namespace PcaGmmGenerator
{
	class Program
	{
		static MatlabDelegate _Matlab = new MatlabDelegate();
		static string[] _Suffix = new string[] { "scale3_s_c4_n1", "scale3_s_c4_n2", "scale3_s_c5_n1", "scale3_s_c5_n2", "scale3_t_c3_n1", "scale3_t_c3_n2", "scale3_t_c4_n1", "scale3_t_c4_n2" };
		
		static Random _Rand = new Random();

		static void ShuffleList(ref List<string> list)
		{
			var n = list.Count;
			while (n > 1)
			{
				var k = _Rand.Next(n--);
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		static List<string> FindAllAvi(string dir, int depth)
		{
			List<string> rv = new List<string>();
			if (depth <= 0) return rv;

			foreach (var file in Directory.GetFiles(dir))
				if ((!Path.GetFileName(file).StartsWith("K_")) && (Path.GetExtension(file) == ".avi"))
					rv.Add(file);
			foreach (var subdir in Directory.GetDirectories(dir)) rv.AddRange(FindAllAvi(subdir, depth - 1));

			return rv;
		}

		// Return: Processed, checked paths to '.mat' files.
		static List<string> GetValidMats(List<string> list, string suffix)
		{
			var rv = new List<string>();
			
			foreach (var path in list)
			{
				var matPath = Path.GetDirectoryName(path) + @"\Result\" + Path.GetFileNameWithoutExtension(path) + '_' + suffix + ".mat";
				if (!File.Exists(matPath)) continue;
				rv.Add(matPath);
			}

			return rv;
		}

		static void Main(string[] args)
		{
			const int SIZE_USED = 12500;
			
			string pcaOut = AppDomain.CurrentDomain.BaseDirectory + @"PCA\";
			if (!Directory.Exists(pcaOut)) Directory.CreateDirectory(pcaOut);
			string gmmOut = AppDomain.CurrentDomain.BaseDirectory + @"GMM\";
			if (!Directory.Exists(gmmOut)) Directory.CreateDirectory(gmmOut);

			var list = new List<string>();
			foreach (var dir in args) list.AddRange(FindAllAvi(dir, 5));

			ShuffleList(ref list);
			if (list.Count > SIZE_USED)
				list = list.GetRange(0, SIZE_USED); // 100,000 TDDs from 12,500 vids.

			foreach (var suffix in _Suffix)
			{
				_Matlab.GeneratePcaGmm(GetValidMats(list, suffix),suffix, pcaOut, gmmOut);
			}
		}
	}
}

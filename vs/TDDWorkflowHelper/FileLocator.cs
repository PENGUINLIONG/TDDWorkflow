using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LiongStudio.ComputerVision.Utils
{
	public static class FileLocator
	{
		/// <summary>
		/// Find all '.avi' files recursively in <paramref name="searchRoot"/>.
		/// </summary>
		/// <param name="searchRoot">The root directory that will be searched.</param>
		/// <param name="depth">the maximum depth of recursion</param>
		/// <param name="shouldQuoteResult">Determines if output string should be parsed by quote '\"'</param>
		/// <returns>All '.avi' files found in <paramref name="searchRoot"/> in <paramref name="depth"/> recursionat most.</returns>
		public static List<string> FindAllAvi(string searchRoot, int depth, bool shouldQuoteResult = true)
		{
			if (depth < 0) throw new ArgumentOutOfRangeException("$depth is negative.");
			if (searchRoot == null) throw new ArgumentNullException("$searchRoot is null.");

			List<string> rv = new List<string>();
			if (depth <= 0) return rv;
			
			foreach (var file in Directory.GetFiles(searchRoot))
				// The commented part is used to omit depth vids from Kinect.
				if (/*(!Path.GetFileName(file).StartsWith("K_")) && */(Path.GetExtension(file) == ".avi"))
					rv.Add(shouldQuoteResult ? '\"' + file + '\"' : file);
			foreach (var subdir in Directory.GetDirectories(searchRoot)) rv.AddRange(FindAllAvi(subdir, depth - 1));

			return rv;
		}
	}
}

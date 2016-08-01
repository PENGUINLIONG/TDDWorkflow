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

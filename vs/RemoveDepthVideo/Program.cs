using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoveDepthVideo
{
	class Program
	{
		static void RemoveAllDepthVideo(string dir, int depth)
		{
			if (depth <= 0) return;

			foreach (var file in Directory.GetFiles(dir)) if (Path.GetFileName(file).StartsWith("K_") && Path.GetExtension(file) == ".avi") File.Delete(file);
			foreach (var subdir in Directory.GetDirectories(dir)) RemoveAllDepthVideo(subdir, depth);
		}

		static void Main(string[] args)
		{
			foreach (var dir in args)
			{
				RemoveAllDepthVideo(dir, 5);
			}
		}
	}
}

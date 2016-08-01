using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiongStudio.ComputerVision.Tdd;
using MathWorks.MATLAB.NET.Arrays;

namespace LiongStudio.ComputerVision.Tdd
{
    public class MatlabDelegate : IDisposable
    {
		private bool _IsDisposed = false;
		private Tdd _Tdd = new Tdd();

		public MatlabDelegate()
		{
		}

		public void ExtractFisherVector(string pcaPath1, string pcaPath2,
			string gmmPath1, string gmmPath2,
			string inputDir, string inputFileNameNoEx1, string inputFileNameNoEx2,
			string outputDir)
		{
			_Tdd.ExtractFisherVector(pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameNoEx1, inputFileNameNoEx2, outputDir);
		}

		public void ExtractTddFeature(string envPath, string inputDir, string inputFileNameNoEx,
			string outputDir, int scale, int gpuId)
		{
			_Tdd.ExtractTddFeature(envPath, inputDir, inputFileNameNoEx, outputDir, scale, gpuId);
		}

		public void GeneratePcaGmm(List<string> inputFilePaths, string outputFileName,
			string pcaOutputFileDir, string gmmOutputFileDir)
		{
			var count = inputFilePaths.Count;
			MWCellArray carray = new MWCellArray(count, 1);
			for (int i = 0; i < count; ++i)
				carray[i + 1] = inputFilePaths[i];
			_Tdd.GeneratePca(carray, outputFileName, pcaOutputFileDir);
			_Tdd.GenerateGmm(carray, pcaOutputFileDir + outputFileName + ".mat", outputFileName, gmmOutputFileDir);
		}

		public int GetVideoFrameCount(string vidPath)
		{
			return (_Tdd.GetVideoFrameCount(vidPath) as MathWorks.MATLAB.NET.Arrays.MWNumericArray).ToScalarInteger();
		}

		public void Dispose()
		{
			if (!_IsDisposed)
				_Tdd.Dispose();
		}
	}
}

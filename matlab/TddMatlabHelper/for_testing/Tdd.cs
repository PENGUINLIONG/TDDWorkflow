/*
* MATLAB Compiler: 6.1 (R2015b)
* Date: Mon Aug 01 11:04:55 2016
* Arguments: "-B" "macro_default" "-W"
* "dotnet:LiongStudio.ComputerVision.Tdd,Tdd,0.0,private" "-T" "link:lib" "-d"
* "P:\TDDWorkflow\matlab\TddMatlabHelper\for_testing" "-v"
* "class{Tdd:P:\TDDWorkflow\matlab\ExtractFisherVector.m,P:\TDDWorkflow\matlab\ExtractTddF
* eature.m,P:\TDDWorkflow\matlab\GenerateGmm.m,P:\TDDWorkflow\matlab\GeneratePca.m,P:\TDDW
* orkflow\matlab\GetVideoFrameCount.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace LiongStudio.ComputerVision.Tdd
{

  /// <summary>
  /// The Tdd class provides a CLS compliant, MWArray interface to the MATLAB functions
  /// contained in the files:
  /// <newpara></newpara>
  /// P:\TDDWorkflow\matlab\ExtractFisherVector.m
  /// <newpara></newpara>
  /// P:\TDDWorkflow\matlab\ExtractTddFeature.m
  /// <newpara></newpara>
  /// P:\TDDWorkflow\matlab\GenerateGmm.m
  /// <newpara></newpara>
  /// P:\TDDWorkflow\matlab\GeneratePca.m
  /// <newpara></newpara>
  /// P:\TDDWorkflow\matlab\GetVideoFrameCount.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Tdd : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Tdd()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "Tdd.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Tdd class.
    /// </summary>
    public Tdd()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Tdd()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    ///
    public void ExtractFisherVector()
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1, 
                              MWArray gmmPath2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2);
    }


    /// <summary>
    /// Provides a void output, 5-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1, 
                              MWArray gmmPath2, MWArray inputDir)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir);
    }


    /// <summary>
    /// Provides a void output, 6-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1, 
                              MWArray gmmPath2, MWArray inputDir, MWArray 
                              inputFileNameWithoutExtensionNorm1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1);
    }


    /// <summary>
    /// Provides a void output, 7-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    /// <param name="inputFileNameWithoutExtensionNorm2">Input argument #7</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1, 
                              MWArray gmmPath2, MWArray inputDir, MWArray 
                              inputFileNameWithoutExtensionNorm1, MWArray 
                              inputFileNameWithoutExtensionNorm2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2);
    }


    /// <summary>
    /// Provides a void output, 8-input MWArrayinterface to the ExtractFisherVector
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    /// <param name="inputFileNameWithoutExtensionNorm2">Input argument #7</param>
    /// <param name="outputDir">Input argument #8</param>
    ///
    public void ExtractFisherVector(MWArray pcaPath1, MWArray pcaPath2, MWArray gmmPath1, 
                              MWArray gmmPath2, MWArray inputDir, MWArray 
                              inputFileNameWithoutExtensionNorm1, MWArray 
                              inputFileNameWithoutExtensionNorm2, MWArray outputDir)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2, outputDir);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1, MWArray gmmPath2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1, MWArray gmmPath2, MWArray 
                                   inputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1, MWArray gmmPath2, MWArray 
                                   inputDir, MWArray inputFileNameWithoutExtensionNorm1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    /// <param name="inputFileNameWithoutExtensionNorm2">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1, MWArray gmmPath2, MWArray 
                                   inputDir, MWArray inputFileNameWithoutExtensionNorm1, 
                                   MWArray inputFileNameWithoutExtensionNorm2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2);
    }


    /// <summary>
    /// Provides the standard 8-input MWArray interface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    /// <param name="gmmPath2">Input argument #4</param>
    /// <param name="inputDir">Input argument #5</param>
    /// <param name="inputFileNameWithoutExtensionNorm1">Input argument #6</param>
    /// <param name="inputFileNameWithoutExtensionNorm2">Input argument #7</param>
    /// <param name="outputDir">Input argument #8</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractFisherVector(int numArgsOut, MWArray pcaPath1, MWArray 
                                   pcaPath2, MWArray gmmPath1, MWArray gmmPath2, MWArray 
                                   inputDir, MWArray inputFileNameWithoutExtensionNorm1, 
                                   MWArray inputFileNameWithoutExtensionNorm2, MWArray 
                                   outputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2, outputDir);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    ///
    public void ExtractTddFeature()
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    ///
    public void ExtractTddFeature(MWArray envPath)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    ///
    public void ExtractTddFeature(MWArray envPath, MWArray inputDir)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    ///
    public void ExtractTddFeature(MWArray envPath, MWArray inputDir, MWArray 
                            inputFileNameWithoutExtension)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    ///
    public void ExtractTddFeature(MWArray envPath, MWArray inputDir, MWArray 
                            inputFileNameWithoutExtension, MWArray outputDir)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir);
    }


    /// <summary>
    /// Provides a void output, 5-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    /// <param name="scale">Input argument #5</param>
    ///
    public void ExtractTddFeature(MWArray envPath, MWArray inputDir, MWArray 
                            inputFileNameWithoutExtension, MWArray outputDir, MWArray 
                            scale)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale);
    }


    /// <summary>
    /// Provides a void output, 6-input MWArrayinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    /// <param name="scale">Input argument #5</param>
    /// <param name="gpuId">Input argument #6</param>
    ///
    public void ExtractTddFeature(MWArray envPath, MWArray inputDir, MWArray 
                            inputFileNameWithoutExtension, MWArray outputDir, MWArray 
                            scale, MWArray gpuId)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale, gpuId);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath, MWArray inputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath, MWArray inputDir, 
                                 MWArray inputFileNameWithoutExtension)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath, MWArray inputDir, 
                                 MWArray inputFileNameWithoutExtension, MWArray outputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    /// <param name="scale">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath, MWArray inputDir, 
                                 MWArray inputFileNameWithoutExtension, MWArray 
                                 outputDir, MWArray scale)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    /// <param name="inputFileNameWithoutExtension">Input argument #3</param>
    /// <param name="outputDir">Input argument #4</param>
    /// <param name="scale">Input argument #5</param>
    /// <param name="gpuId">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] ExtractTddFeature(int numArgsOut, MWArray envPath, MWArray inputDir, 
                                 MWArray inputFileNameWithoutExtension, MWArray 
                                 outputDir, MWArray scale, MWArray gpuId)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale, gpuId);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void GenerateGmm()
    {
      mcr.EvaluateFunction(0, "GenerateGmm", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    ///
    public void GenerateGmm(MWArray inputFilePaths)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    ///
    public void GenerateGmm(MWArray inputFilePaths, MWArray pcaFilePath)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    ///
    public void GenerateGmm(MWArray inputFilePaths, MWArray pcaFilePath, MWArray 
                      outputFileName)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName);
    }


    /// <summary>
    /// Provides a void output, 4-input MWArrayinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    /// <param name="outputFileDir">Input argument #4</param>
    ///
    public void GenerateGmm(MWArray inputFilePaths, MWArray pcaFilePath, MWArray 
                      outputFileName, MWArray outputFileDir)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GenerateGmm(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GenerateGmm(int numArgsOut, MWArray inputFilePaths)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GenerateGmm(int numArgsOut, MWArray inputFilePaths, MWArray 
                           pcaFilePath)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GenerateGmm(int numArgsOut, MWArray inputFilePaths, MWArray 
                           pcaFilePath, MWArray outputFileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    /// <param name="outputFileDir">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GenerateGmm(int numArgsOut, MWArray inputFilePaths, MWArray 
                           pcaFilePath, MWArray outputFileName, MWArray outputFileDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void GeneratePca()
    {
      mcr.EvaluateFunction(0, "GeneratePca", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    ///
    public void GeneratePca(MWArray inputFilePaths)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    ///
    public void GeneratePca(MWArray inputFilePaths, MWArray outputFileName)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths, outputFileName);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    /// <param name="outputFileDir">Input argument #3</param>
    ///
    public void GeneratePca(MWArray inputFilePaths, MWArray outputFileName, MWArray 
                      outputFileDir)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GeneratePca(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GeneratePca(int numArgsOut, MWArray inputFilePaths)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GeneratePca(int numArgsOut, MWArray inputFilePaths, MWArray 
                           outputFileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths, outputFileName);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    /// <param name="outputFileDir">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GeneratePca(int numArgsOut, MWArray inputFilePaths, MWArray 
                           outputFileName, MWArray outputFileDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the GetVideoFrameCount
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray GetVideoFrameCount()
    {
      return mcr.EvaluateFunction("GetVideoFrameCount", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the GetVideoFrameCount
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="fileName">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray GetVideoFrameCount(MWArray fileName)
    {
      return mcr.EvaluateFunction("GetVideoFrameCount", fileName);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the GetVideoFrameCount MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GetVideoFrameCount(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GetVideoFrameCount", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the GetVideoFrameCount MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="fileName">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] GetVideoFrameCount(int numArgsOut, MWArray fileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GetVideoFrameCount", fileName);
    }


    /// <summary>
    /// Provides an interface for the GetVideoFrameCount function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void GetVideoFrameCount(int numArgsOut, ref MWArray[] argsOut, MWArray[] 
                         argsIn)
    {
      mcr.EvaluateFunction("GetVideoFrameCount", numArgsOut, ref argsOut, argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}

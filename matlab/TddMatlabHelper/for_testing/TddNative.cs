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

namespace LiongStudio.ComputerVision.TddNative
{

  /// <summary>
  /// The Tdd class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
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
    /// Provides a void output, 0-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    ///
    public void ExtractFisherVector()
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    ///
    public void ExtractFisherVector(Object pcaPath1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    ///
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="pcaPath1">Input argument #1</param>
    /// <param name="pcaPath2">Input argument #2</param>
    /// <param name="gmmPath1">Input argument #3</param>
    ///
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
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
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1, 
                              Object gmmPath2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2);
    }


    /// <summary>
    /// Provides a void output, 5-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
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
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1, 
                              Object gmmPath2, Object inputDir)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir);
    }


    /// <summary>
    /// Provides a void output, 6-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
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
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1, 
                              Object gmmPath2, Object inputDir, Object 
                              inputFileNameWithoutExtensionNorm1)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1);
    }


    /// <summary>
    /// Provides a void output, 7-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
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
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1, 
                              Object gmmPath2, Object inputDir, Object 
                              inputFileNameWithoutExtensionNorm1, Object 
                              inputFileNameWithoutExtensionNorm2)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2);
    }


    /// <summary>
    /// Provides a void output, 8-input Objectinterface to the ExtractFisherVector MATLAB
    /// function.
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
    public void ExtractFisherVector(Object pcaPath1, Object pcaPath2, Object gmmPath1, 
                              Object gmmPath2, Object inputDir, Object 
                              inputFileNameWithoutExtensionNorm1, Object 
                              inputFileNameWithoutExtensionNorm2, Object outputDir)
    {
      mcr.EvaluateFunction(0, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2, outputDir);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1, Object gmmPath2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1, Object gmmPath2, Object inputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1, Object gmmPath2, Object inputDir, 
                                  Object inputFileNameWithoutExtensionNorm1)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1, Object gmmPath2, Object inputDir, 
                                  Object inputFileNameWithoutExtensionNorm1, Object 
                                  inputFileNameWithoutExtensionNorm2)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2);
    }


    /// <summary>
    /// Provides the standard 8-input Object interface to the ExtractFisherVector MATLAB
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
    public Object[] ExtractFisherVector(int numArgsOut, Object pcaPath1, Object pcaPath2, 
                                  Object gmmPath1, Object gmmPath2, Object inputDir, 
                                  Object inputFileNameWithoutExtensionNorm1, Object 
                                  inputFileNameWithoutExtensionNorm2, Object outputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractFisherVector", pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2, outputDir);
    }


    /// <summary>
    /// Provides an interface for the ExtractFisherVector function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// Number of feature held.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("ExtractFisherVector", 8, 0, 0)]
    protected void ExtractFisherVector(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("ExtractFisherVector", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    ///
    public void ExtractTddFeature()
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    ///
    public void ExtractTddFeature(Object envPath)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the ExtractTddFeature MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="envPath">Input argument #1</param>
    /// <param name="inputDir">Input argument #2</param>
    ///
    public void ExtractTddFeature(Object envPath, Object inputDir)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the ExtractTddFeature MATLAB
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
    public void ExtractTddFeature(Object envPath, Object inputDir, Object 
                            inputFileNameWithoutExtension)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the ExtractTddFeature MATLAB
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
    public void ExtractTddFeature(Object envPath, Object inputDir, Object 
                            inputFileNameWithoutExtension, Object outputDir)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir);
    }


    /// <summary>
    /// Provides a void output, 5-input Objectinterface to the ExtractTddFeature MATLAB
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
    public void ExtractTddFeature(Object envPath, Object inputDir, Object 
                            inputFileNameWithoutExtension, Object outputDir, Object scale)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale);
    }


    /// <summary>
    /// Provides a void output, 6-input Objectinterface to the ExtractTddFeature MATLAB
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
    public void ExtractTddFeature(Object envPath, Object inputDir, Object 
                            inputFileNameWithoutExtension, Object outputDir, Object 
                            scale, Object gpuId)
    {
      mcr.EvaluateFunction(0, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale, gpuId);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath, Object inputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath, Object inputDir, 
                                Object inputFileNameWithoutExtension)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath, Object inputDir, 
                                Object inputFileNameWithoutExtension, Object outputDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath, Object inputDir, 
                                Object inputFileNameWithoutExtension, Object outputDir, 
                                Object scale)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the ExtractTddFeature MATLAB
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
    public Object[] ExtractTddFeature(int numArgsOut, Object envPath, Object inputDir, 
                                Object inputFileNameWithoutExtension, Object outputDir, 
                                Object scale, Object gpuId)
    {
      return mcr.EvaluateFunction(numArgsOut, "ExtractTddFeature", envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale, gpuId);
    }


    /// <summary>
    /// Provides an interface for the ExtractTddFeature function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("ExtractTddFeature", 6, 0, 0)]
    protected void ExtractTddFeature(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("ExtractTddFeature", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void GenerateGmm()
    {
      mcr.EvaluateFunction(0, "GenerateGmm", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    ///
    public void GenerateGmm(Object inputFilePaths)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    ///
    public void GenerateGmm(Object inputFilePaths, Object pcaFilePath)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    ///
    public void GenerateGmm(Object inputFilePaths, Object pcaFilePath, Object 
                      outputFileName)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="pcaFilePath">Input argument #2</param>
    /// <param name="outputFileName">Input argument #3</param>
    /// <param name="outputFileDir">Input argument #4</param>
    ///
    public void GenerateGmm(Object inputFilePaths, Object pcaFilePath, Object 
                      outputFileName, Object outputFileDir)
    {
      mcr.EvaluateFunction(0, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GenerateGmm(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the GenerateGmm MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GenerateGmm(int numArgsOut, Object inputFilePaths)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the GenerateGmm MATLAB
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
    public Object[] GenerateGmm(int numArgsOut, Object inputFilePaths, Object pcaFilePath)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the GenerateGmm MATLAB
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
    public Object[] GenerateGmm(int numArgsOut, Object inputFilePaths, Object 
                          pcaFilePath, Object outputFileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the GenerateGmm MATLAB
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
    public Object[] GenerateGmm(int numArgsOut, Object inputFilePaths, Object 
                          pcaFilePath, Object outputFileName, Object outputFileDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "GenerateGmm", inputFilePaths, pcaFilePath, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides an interface for the GenerateGmm function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("GenerateGmm", 4, 0, 0)]
    protected void GenerateGmm(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("GenerateGmm", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void GeneratePca()
    {
      mcr.EvaluateFunction(0, "GeneratePca", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    ///
    public void GeneratePca(Object inputFilePaths)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    ///
    public void GeneratePca(Object inputFilePaths, Object outputFileName)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths, outputFileName);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <param name="outputFileName">Input argument #2</param>
    /// <param name="outputFileDir">Input argument #3</param>
    ///
    public void GeneratePca(Object inputFilePaths, Object outputFileName, Object 
                      outputFileDir)
    {
      mcr.EvaluateFunction(0, "GeneratePca", inputFilePaths, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GeneratePca(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the GeneratePca MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inputFilePaths">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GeneratePca(int numArgsOut, Object inputFilePaths)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the GeneratePca MATLAB
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
    public Object[] GeneratePca(int numArgsOut, Object inputFilePaths, Object 
                          outputFileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths, outputFileName);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the GeneratePca MATLAB
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
    public Object[] GeneratePca(int numArgsOut, Object inputFilePaths, Object 
                          outputFileName, Object outputFileDir)
    {
      return mcr.EvaluateFunction(numArgsOut, "GeneratePca", inputFilePaths, outputFileName, outputFileDir);
    }


    /// <summary>
    /// Provides an interface for the GeneratePca function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("GeneratePca", 3, 0, 0)]
    protected void GeneratePca(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("GeneratePca", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the GetVideoFrameCount
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object GetVideoFrameCount()
    {
      return mcr.EvaluateFunction("GetVideoFrameCount", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the GetVideoFrameCount
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="fileName">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object GetVideoFrameCount(Object fileName)
    {
      return mcr.EvaluateFunction("GetVideoFrameCount", fileName);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the GetVideoFrameCount MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GetVideoFrameCount(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "GetVideoFrameCount", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the GetVideoFrameCount MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="fileName">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] GetVideoFrameCount(int numArgsOut, Object fileName)
    {
      return mcr.EvaluateFunction(numArgsOut, "GetVideoFrameCount", fileName);
    }


    /// <summary>
    /// Provides an interface for the GetVideoFrameCount function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("GetVideoFrameCount", 1, 1, 0)]
    protected void GetVideoFrameCount(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("GetVideoFrameCount", numArgsOut, ref argsOut, argsIn, varArgsIn);
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

using System.Diagnostics;
using Plainion.DrawVista.UseCases;

namespace Plainion.DrawVista.IO;

internal class DotApp(DotFileModel DotFileModel) : IDisposable
{
    private readonly DotFileModel myDotFileModel = DotFileModel;

    private string myFile;
    private static readonly string Executable = Path.Combine(@"D:\Hari\Utils\Plainion.GraphViz-3.5", "dot.exe");

    public string ExtractSvg()
    {
        SaveModelOnDemand();

        Process.Start(Executable, $"-Tsvg {myFile} -O")
            .WaitForExit();

        return myFile + ".svg";
    }

    
    private void SaveModelOnDemand()
    {
        if (myFile != null)
        {
            return;
        }

        myFile = Path.GetTempFileName() + ".dot";
        
        myDotFileModel.WriteTo(myFile);
    }

    public void Dispose()
    {
        if (File.Exists(myFile))
        {
            File.Delete(myFile);
        }
    }
}
using System.Diagnostics;
using Plainion.DrawVista.UseCases;

namespace Plainion.DrawVista.IO;

internal class SvgIndexCreator : ISvgIndexCreator
{
    public RawDocument CreateAutoIndexSvg(IDictionary<string, IList<string>> pageToReferencesMap)
    {
        Console.WriteLine("!!! Creating dot language file !!!");
        var dotFileModel = new DotFileModel(pageToReferencesMap);
        
        Console.WriteLine("!!! Creating auto generated index graph in svg file !!!");
        var dotApp = new DotApp(dotFileModel);
        var svgFileName = dotApp.ExtractSvg();

        return new RawDocument("Index (AutoGen)", File.ReadAllText(svgFileName));
    }
}

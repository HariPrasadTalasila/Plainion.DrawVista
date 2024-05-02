using Plainion.DrawVista.UseCases;

namespace Plainion.DrawVista.IO;

public interface ISvgIndexCreator
{
    public RawDocument CreateAutoIndexSvg(IDictionary<string, IList<string>> pageToReferencesMap);
}
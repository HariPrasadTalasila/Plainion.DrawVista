
using Plainion.DrawVista.UseCases;

namespace Plainion.DrawVista.Adapters;

public class SvgCaptionParserFactory : ISvgCaptionParserFactory
{
    public ISvgCaptionParser CreateParser(string parserName)
    {
        if(parserName == "DrawIO") return new SvgDrawIOCaptionParser();
        else if(parserName == "DotGraph") return new SvgDotGraphCaptionParser();
        else throw new InvalidOperationException($"Unexpected Svg Caption parser requested: {parserName}");
    }
}

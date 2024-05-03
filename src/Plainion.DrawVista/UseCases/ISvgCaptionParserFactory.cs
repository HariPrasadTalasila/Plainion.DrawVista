namespace Plainion.DrawVista.UseCases;

public interface ISvgCaptionParserFactory
{
    public ISvgCaptionParser CreateParser(string parserName);
}
﻿var drawIOFile = args[0];

Console.WriteLine($"Analyzing file: {drawIOFile}");

if (Path.GetExtension(drawIOFile).Equals(".png", StringComparison.OrdinalIgnoreCase))
{
    var converter = new PngToDrawIoConverter();
    drawIOFile= converter.Convert(drawIOFile);
}

var pageReader = new PageReader(drawIOFile);
var pages = pageReader.ReadPages();

var outputFolder = Path.Combine("src", "browser", "src", "assets");
var svgExporter = new SvgExporter(drawIOFile, outputFolder);

var svgProcessor = new SvgProcessor(pages, new SvgCaptionParser(), new SvgHyperlinkFormatter());

for (int i = 0; i < pages.Count; ++i)
{
    var svgDocument = svgExporter.Export(i, pages[i]);

    svgProcessor.AddLinks(svgDocument);

    svgExporter.Save(svgDocument);
}

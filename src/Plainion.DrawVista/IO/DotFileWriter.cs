using System.Text;

namespace Plainion.DrawVista.UseCases;

internal class DotFileWriter(IDictionary<string, IList<string>> PageToReferencesMap)
{
    public void WriteTo(string file)
    {
        StringBuilder graphContent = new();

        foreach (var (pageName, pageReferences) in PageToReferencesMap)
        {
            foreach(var referencedPage in pageReferences)
            {
                graphContent.AppendLine($"{pageName} -> {referencedPage}");
            }
        }

        var fileContent = $"digraph {{ { Environment.NewLine } node [shape = box] { Environment.NewLine } {graphContent} }}";

        File.WriteAllText(file, fileContent);
        Console.WriteLine($"dot file created: {file}");
    }
}
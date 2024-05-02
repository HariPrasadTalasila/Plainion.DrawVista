using System.Text;

namespace Plainion.DrawVista.UseCases;

public class DotFileModel(IDictionary<string, IList<string>> pageToReferencesMap)
{
    private readonly IDictionary<string, IList<string>> myPageToReferencesMap = pageToReferencesMap;

    public void WriteTo(string file)
    {
        StringBuilder graphContent = new();

        foreach (var (pageName, pageReferences) in myPageToReferencesMap)
        {
            if(!pageReferences.Any())
            {
                graphContent.AppendLine($"{pageName}");
            }

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
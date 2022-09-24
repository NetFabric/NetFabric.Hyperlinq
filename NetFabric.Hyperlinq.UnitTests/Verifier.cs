using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator.UnitTests
{
    sealed class Verifier
    {
        static readonly string defaultFilePathPrefix = "Test";
        static readonly string testProjectName = "TestProject";

        public static Project CreateProject(IEnumerable<string> sources)
        {
            var projectId = ProjectId.CreateNewId(debugName: testProjectName);

            var coreLibPath = typeof(object).Assembly.Location;
            var coreLibDirectory = Path.GetDirectoryName(coreLibPath)!;
            var references = new[] {
                    MetadataReference.CreateFromFile(coreLibPath),
                    MetadataReference.CreateFromFile(Path.Combine(coreLibDirectory, "netstandard.dll")),
                    MetadataReference.CreateFromFile(Path.Combine(coreLibDirectory, "System.Runtime.dll")),
                    MetadataReference.CreateFromFile(Path.Combine(coreLibDirectory, "System.Collections.dll")),
                    MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(ImmutableArray<>).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(IValueEnumerable<,>).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(ValueEnumerableExtensions).Assembly.Location),
                };
            var solution = new AdhocWorkspace()
                .CurrentSolution
                .AddProject(projectId, testProjectName, testProjectName, LanguageNames.CSharp)
                .AddMetadataReferences(projectId, references)
                .WithProjectCompilationOptions(projectId, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var count = 0;
            foreach (var source in sources)
            {
                var newFileName = defaultFilePathPrefix + count + ".cs";
                var documentId = DocumentId.CreateNewId(projectId, debugName: newFileName);
                solution = solution.AddDocument(documentId, newFileName, SourceText.From(source));
                count++;
            }
            return solution.GetProject(projectId)!;
        }
    }
}

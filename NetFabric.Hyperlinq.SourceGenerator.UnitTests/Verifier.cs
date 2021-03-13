using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator.UnitTests
{
    sealed class Verifier
    {
        static readonly MetadataReference corlibReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        static readonly MetadataReference systemCoreReference = MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location);
        static readonly MetadataReference cSharpSymbolsReference = MetadataReference.CreateFromFile(typeof(CSharpCompilation).Assembly.Location);
        static readonly MetadataReference codeAnalysisReference = MetadataReference.CreateFromFile(typeof(Compilation).Assembly.Location);

        static readonly string defaultFilePathPrefix = "Test";
        static readonly string testProjectName = "TestProject";

        public static Project CreateProject(IEnumerable<string> sources)
        {
            var projectId = ProjectId.CreateNewId(debugName: testProjectName);

            var solution = new AdhocWorkspace()
                .CurrentSolution
                .AddProject(projectId, testProjectName, testProjectName, LanguageNames.CSharp)
                .AddMetadataReference(projectId, corlibReference)
                .AddMetadataReference(projectId, systemCoreReference)
                .AddMetadataReference(projectId, cSharpSymbolsReference)
                .AddMetadataReference(projectId, codeAnalysisReference);

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

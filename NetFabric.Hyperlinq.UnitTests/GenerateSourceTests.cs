using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetFabric.Assertive;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.SourceGenerator.UnitTests
{
    public class GenerateSourceTests
    {
        public static TheoryData<string[], string> GeneratorSources
            => new()
            {
                {
                    new[] { "TestData/Source/AsValueEnumerable.Empty.cs" },
                    "TestData/Results/Empty.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.Empty2.cs" },
                    "TestData/Results/Empty.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.Empty3.cs" },
                    "TestData/Results/Empty.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.Repeat.cs" },
                    "TestData/Results/AsValueEnumerable.Repeat.cs"
                },

                {
                    new[] { "TestData/Source/AsValueEnumerable.TestEnumerableWithValueTypeEnumerator.cs" },
                    "TestData/Results/AsValueEnumerable.TestEnumerableWithValueTypeEnumerator.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestEnumerableWithReferenceTypeEnumerator.cs" },
                    "TestData/Results/AsValueEnumerable.TestEnumerableWithReferenceTypeEnumerator.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestEnumerableWithNoInterfaces.cs" },
                    "TestData/Results/AsValueEnumerable.TestEnumerableWithNoInterfaces.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose.cs" },
                    "TestData/Results/AsValueEnumerable.TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestEnumerableWithInterfacelessPublicEnumerator.cs" },
                    "TestData/Results/AsValueEnumerable.TestEnumerableWithInterfacelessPublicEnumerator.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestCollection.cs" },
                    "TestData/Results/AsValueEnumerable.TestCollection.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestReadOnlyCollection.cs" },
                    "TestData/Results/AsValueEnumerable.TestReadOnlyCollection.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestList.cs" },
                    "TestData/Results/AsValueEnumerable.TestList.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.IReadOnlyList.cs" },
                    "TestData/Results/AsValueEnumerable.IReadOnlyList.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestListWithExplicitInterfaces.cs" },
                    "TestData/Results/AsValueEnumerable.TestListWithExplicitInterfaces.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestReadOnlyList.cs" },
                    "TestData/Results/AsValueEnumerable.TestReadOnlyList.cs"
                },
                {
                    new[] { "TestData/Source/AsValueEnumerable.TestValueEnumerable.cs" },
                    "TestData/Results/AsValueEnumerable.TestValueEnumerable.cs"
                },
                {
                    new[] { "TestData/Source/Count.Array.cs" },
                    "TestData/Results/Count.Array.cs"
                },
                {
                    new[] { "TestData/Source/Select.Array.cs" },
                    "TestData/Results/Select.Array.cs"
                },
                {
                    new[] { "TestData/Source/Where.Array.cs" },
                    "TestData/Results/Where.Array.cs"
                },
                {
                    new[] { "TestData/Source/Skip.Take.Array.cs" },
                    "TestData/Results/Skip.Take.Array.cs"
                },
                //{
                //    new[] { "TestData/Source/Count.Span.cs" },
                //    "TestData/Results/Count.Span.cs"
                //},
                {
                    new[] { "TestData/Source/AsEnumerable.TestEnumerableWithValueTypeEnumerator.cs" },
                    "TestData/Results/AsEnumerable.TestEnumerableWithValueTypeEnumerator.cs"
                },
                {
                    new[] { "TestData/Source/Select.TestEnumerableWithValueTypeEnumerator.cs" },
                    "TestData/Results/Select.TestEnumerableWithValueTypeEnumerator.cs"
                },
            };

        [Theory]
        [MemberData(nameof(GeneratorSources))]
        public async Task GenerateSourceShouldGenerate(string[] paths, string expected)
        {
            // Arrange
            var sources = paths
                .Concat(Directory.EnumerateFiles("TestData/Source/Common", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path));
            var project = Verifier.CreateProject(sources);
            var compilation = await project.GetCompilationAsync().ConfigureAwait(false) 
                ?? throw new System.Exception("Error getting compilation!");
            //var errors = compilation
            //    .GetDiagnostics()
            //    .Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
            //    .ToArray();
            //_ = errors.Must().BeEqualTo(Array.Empty<Diagnostic>());
            var typeSymbolsCache = new TypeSymbolsCache(compilation);
            var memberAccessExpressions = compilation.SyntaxTrees
                .SelectMany(tree => tree.GetRoot().DescendantNodes().OfType<MemberAccessExpressionSyntax>())
                .Where(memberAccess => Generator.methods.Contains(memberAccess.Name.Identifier.ValueText))
                .ToList();

            // Act
            var builder = new CodeBuilder { IsUnitTest = true };
            Generator.GenerateSource(compilation, typeSymbolsCache, memberAccessExpressions, builder, CancellationToken.None);
            var result = builder.ToString();

            // Assert
#if NET5_0_OR_GREATER            
            _ = result.Must()
                .BeEqualTo(await File.ReadAllTextAsync(expected));
#else
            _ = result.Must()
                .BeEqualTo(File.ReadAllText(expected));
#endif
        }
    }
}
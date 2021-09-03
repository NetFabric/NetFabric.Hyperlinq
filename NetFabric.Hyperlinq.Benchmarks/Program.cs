using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace NetFabric.Hyperlinq.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                .WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend))
                .AddJob(Job.Default
                    .WithRuntime(CoreRuntime.Core60)
                    .WithEnvironmentVariables(
                        new EnvironmentVariable("COMPlus_ReadyToRun", "0"),
                        new EnvironmentVariable("COMPlus_TC_QuickJitForLoops", "1"),
                        new EnvironmentVariable("COMPlus_TieredPGO", "1"))
                    .WithId(".NET 6 PGO"))
                .AddDiagnoser(MemoryDiagnoser.Default);
                
            foreach (var summary in BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config))
                SaveSummary(summary);
        }

        static void SaveSummary(Summary summary)
        {
            var solutionDir = GetSolutionDirectory();
            if (solutionDir is null)
                return;

            var targetType = GetTargetType(summary);
            if (targetType is null)
                return;

            var title = targetType.Name;

            var resultsPath = Path.Combine(solutionDir, "Benchmarks");
            _ = Directory.CreateDirectory(resultsPath);

            var filePath = Path.Combine(resultsPath, $"{title}.md");

            if (File.Exists(filePath))
                File.Delete(filePath);

            using var fileWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            var logger = new StreamLogger(fileWriter);

            logger.WriteLine($"## {title}");
            logger.WriteLine();

            logger.WriteLine("### Source");
            logger.WriteLine($"[{title}.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/{title}.cs)");
            logger.WriteLine();

            logger.WriteLine("### References:");

            var linqVersion = GetInformationalVersion(typeof(Enumerable).Assembly);
            logger.WriteLine($"- Linq: {linqVersion}");

            var linqAsyncVersion = GetInformationalVersion(typeof(AsyncEnumerable).Assembly);
            logger.WriteLine($"- System.Linq.Async: [{linqAsyncVersion}](https://www.nuget.org/packages/System.Linq.Async/{linqAsyncVersion})");

            var interactiveVersion = GetInformationalVersion(typeof(EnumerableEx).Assembly);
            logger.WriteLine($"- System.Interactive: [{interactiveVersion}](https://www.nuget.org/packages/System.Interactive/{interactiveVersion})");

            var interactiveAsyncVersion = GetInformationalVersion(typeof(AsyncEnumerableEx).Assembly);
            logger.WriteLine($"- System.Interactive.Async: [{interactiveAsyncVersion}](https://www.nuget.org/packages/System.Interactive.Async/{interactiveAsyncVersion})");

            var structLinqVersion = GetInformationalVersion(typeof(StructLinq.StructEnumerable).Assembly);
            logger.WriteLine($"- StructLinq: [{structLinqVersion}](https://www.nuget.org/packages/StructLinq/{structLinqVersion})");

            var hyperlinqVersion = GetInformationalVersion(typeof(ValueEnumerable).Assembly);
            logger.WriteLine($"- NetFabric.Hyperlinq: [{hyperlinqVersion}](https://www.nuget.org/packages/NetFabric.Hyperlinq/{hyperlinqVersion})");

            logger.WriteLine();

            logger.WriteLine("### Results:");
            MarkdownExporter.GitHub.ExportToLog(summary, logger);
        }

        static string GetInformationalVersion(Assembly assembly)
            => GetCustomAttribute<AssemblyInformationalVersionAttribute>(assembly)?.InformationalVersion.Split('+')[0] ?? "<unknown>";

        static T? GetCustomAttribute<T>(Assembly assembly) where T : Attribute
            => (T?)Attribute.GetCustomAttribute(assembly, typeof(T), false);

        static Type? GetTargetType(Summary summary)
        {
            var targetTypes = summary.BenchmarksCases.Select(i => i.Descriptor.Type).Distinct().ToList();
            return targetTypes.Count == 1 ? targetTypes[0] : null;
        }

        static string? GetSolutionDirectory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            while (dir is not null and { Length: not 0 })
            {
                if (Directory.EnumerateFiles(dir, "*.sln", SearchOption.TopDirectoryOnly).Any())
                    return dir;

                dir = Path.GetDirectoryName(dir);
            }

            return default;
        }
    }
}

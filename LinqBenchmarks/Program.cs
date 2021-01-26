using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var summary in BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args))
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
            var pointIndex = targetType.Namespace.IndexOf('.');
            if (pointIndex >= 0)
                title = $"{EndSubstring(targetType.Namespace, pointIndex + 1)}.{targetType.Name}";

            var resultsPath = Path.Combine(solutionDir, "Results");
            _ = Directory.CreateDirectory(resultsPath);

            var filePath = Path.Combine(resultsPath, $"{title}.md");

            if (File.Exists(filePath))
                File.Delete(filePath);

            using var fileWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            var logger = new StreamLogger(fileWriter);

            logger.WriteLine($"## {title}");
            logger.WriteLine();

            logger.WriteLine("### Source");
            var sourceLink = new StringBuilder("../LinqBenchmarks");
            foreach (var folder in targetType.Namespace.Split('.').AsEnumerable().Skip(1))
                _ = sourceLink.Append($"/{folder}");
            _ = sourceLink.Append($"/{targetType.Name}.cs");
            logger.WriteLine($"[{targetType.Name}.cs]({sourceLink})");
            logger.WriteLine();

            logger.WriteLine("### References:");

            var linqFasterVersion = GetInformationalVersion(typeof(LinqFaster).Assembly);
            logger.WriteLine($"- JM.LinqFaster: [{linqFasterVersion}](https://www.nuget.org/packages/JM.LinqFaster/{linqFasterVersion})");

            var linqAfVersion = GetFileVersion(typeof(LinqAF.Enumerable).Assembly);
            logger.WriteLine($"- LinqAF: [{linqAfVersion}](https://www.nuget.org/packages/LinqAF/{linqAfVersion})");

            var structLinqVersion = GetInformationalVersion(typeof(StructLinq.BCL.List.ListEnumerable<>).Assembly);
            logger.WriteLine($"- StructLinq.BCL: [{structLinqVersion}](https://www.nuget.org/packages/StructLinq.BCL/{structLinqVersion})");

            var hyperlinqVersion = GetInformationalVersion(typeof(ValueEnumerable).Assembly);
            logger.WriteLine($"- NetFabric.Hyperlinq: [{hyperlinqVersion}](https://www.nuget.org/packages/NetFabric.Hyperlinq/{hyperlinqVersion})");

            logger.WriteLine();

            logger.WriteLine("### Results:");
            MarkdownExporter.GitHub.ExportToLog(summary, logger);
        }

        static string EndSubstring(string str, int index)
            => str.Substring(index, str.Length - index);

        static string GetInformationalVersion(Assembly assembly)
            => GetCustomAttribute<AssemblyInformationalVersionAttribute>(assembly)?.InformationalVersion.Split('+')[0];

        static string GetFileVersion(Assembly assembly)
            => GetCustomAttribute<AssemblyFileVersionAttribute>(assembly)?.Version;

        static T GetCustomAttribute<T>(Assembly assembly) where T : Attribute
            => (T)Attribute.GetCustomAttribute(assembly, typeof(T), false);

        static Type GetTargetType(Summary summary)
        {
            var targetTypes = summary.BenchmarksCases.AsValueEnumerable().Select(i => i.Descriptor.Type).Distinct().ToList();
            return targetTypes.Count == 1 ? targetTypes[0] : null;
        }

        static string GetSolutionDirectory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            while (!string.IsNullOrEmpty(dir))
            {
                if (Directory.EnumerateFiles(dir, "*.sln", SearchOption.TopDirectoryOnly).Any())
                    return dir;

                dir = Path.GetDirectoryName(dir);
            }

            return null;
        }
    }
}

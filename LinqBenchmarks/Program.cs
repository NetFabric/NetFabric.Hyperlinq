using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CommandLine;
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

            var title = GetTitle(summary);
            if (title is null)
                return;

            var resultsPath = Path.Combine(solutionDir, "Results");
            _ = Directory.CreateDirectory(resultsPath);

            var filePath = Path.Combine(resultsPath, $"{title}.md");

            if (File.Exists(filePath))
                File.Delete(filePath);

            using var fileWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            var logger = new StreamLogger(fileWriter);

            logger.WriteLine($"## {title}");
            logger.WriteLine();

            var linqFasterVersion = GetVersion(typeof(LinqFaster).Assembly);
            logger.WriteLine($"- JM.LinqFaster: [{linqFasterVersion}](https://www.nuget.org/packages/JM.LinqFaster/{linqFasterVersion})");

            var structLinqVersion = GetVersion(typeof(StructLinq.BCL.List.ListEnumerable<>).Assembly);
            logger.WriteLine($"- StructLinq.BCL: [{structLinqVersion}](https://www.nuget.org/packages/StructLinq.BCL/{structLinqVersion})");

            var hyperlinqVersion = GetVersion(typeof(ValueEnumerable).Assembly);
            logger.WriteLine($"- NetFabric.Hyperlinq: [{hyperlinqVersion}](https://www.nuget.org/packages/NetFabric.Hyperlinq/{hyperlinqVersion})");

            logger.WriteLine();

            MarkdownExporter.GitHub.ExportToLog(summary, logger);
        }

        static string GetVersion(Assembly assembly)
        {
            var version = ((AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyInformationalVersionAttribute), false))?.InformationalVersion ?? string.Empty;
            return version.Split('+')[0];
        }

        static string GetTitle(Summary summary)
        {
            var targetTypes = summary.BenchmarksCases.Select(i => i.Descriptor.Type).Distinct().ToList();
            return targetTypes.Count == 1 ? targetTypes[0].Name : null;
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

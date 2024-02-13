using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.IO;
using System.Reflection;
using System.Text;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

#if DEBUG

var config = new DebugInProcessConfig()
    .AddJob(Job.Dry
        .WithRuntime(CoreRuntime.Core60)
        .WithId(".NET 6 (DRY)")
    );

#else

var config = DefaultConfig.Instance
    .WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend))
    .AddDiagnoser(MemoryDiagnoser.Default)
    //.AddJob(Job.Default
    //    .WithRuntime(ClrRuntime.Net481)
    //)
    //.AddJob(Job.Default
    //    .WithRuntime(CoreRuntime.Core31)
    //)
    // .AddJob(Job.Default
    //     .WithRuntime(CoreRuntime.Core50)
    // )
    //.AddJob(Job.Default
    //    .WithRuntime(CoreRuntime.Core60)
    //)
    //.AddJob(Job.Default
    //    .WithRuntime(CoreRuntime.Core60)
    //    .WithEnvironmentVariables(
    //        new EnvironmentVariable("DOTNET_ReadyToRun", "0"), // Disable AOT
    //        new EnvironmentVariable("DOTNET_TC_QuickJitForLoops", "1"), // Enable Quick Jit for loop
    //        new EnvironmentVariable("DOTNET_TieredPGO", "1")) // Turn on layered PGO
    //)
    .AddJob(Job.Default
        .WithRuntime(CoreRuntime.Core80)
    )
    .AddJob(Job.Default
        .WithRuntime(CoreRuntime.Core90)
    );

#endif

foreach (var summary in BenchmarkSwitcher.FromAssembly(typeof(LinqBenchmarks.Utils).Assembly).Run(args, config))
    SaveSummary(summary);

        
static void SaveSummary(Summary summary)
{
    var solutionDir = GetSolutionDirectory();
    if (solutionDir is null)
        return;

    var targetType = GetTargetType(summary);
    if (targetType is null)
        return;

    var title = targetType.Name;
    var pointIndex = targetType.Namespace?.IndexOf('.') ?? -1;
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
    foreach (var folder in targetType.Namespace?.Split('.').AsEnumerable().Skip(1) ?? Enumerable.Empty<string>())
        _ = sourceLink.Append($"/{folder}");
    _ = sourceLink.Append($"/{targetType.Name}.cs");
    logger.WriteLine($"[{targetType.Name}.cs]({sourceLink})");
    logger.WriteLine();

    logger.WriteLine("### References:");

    // var valueLinqVersion = GetInformationalVersion(typeof(Cistern.ValueLinq.Enumerable).Assembly);
    // logger.WriteLine($"- Cistern.ValueLinq: [{valueLinqVersion}](https://www.nuget.org/packages/Cistern.ValueLinq/{valueLinqVersion})");

    var linqFasterVersion = GetInformationalVersion(typeof(LinqFaster).Assembly);
    logger.WriteLine($"- JM.LinqFaster: [{linqFasterVersion}](https://www.nuget.org/packages/JM.LinqFaster/{linqFasterVersion})");

    var linqFasterSimdVersion = GetInformationalVersion(typeof(LinqFasterSIMD).Assembly);
    logger.WriteLine($"- LinqFaster.SIMD: [{linqFasterVersion}](https://www.nuget.org/packages/LinqFaster.SIMD/{linqFasterSimdVersion})");

    var linqFastererVersion = GetInformationalVersion(typeof(EnumerableF).Assembly);
    logger.WriteLine($"- LinqFasterer: [{linqFastererVersion}](https://www.nuget.org/packages/LinqFasterer/{linqFastererVersion})");

    var linqAfVersion = GetFileVersion(typeof(LinqAF.Enumerable).Assembly);
    logger.WriteLine($"- LinqAF: [{linqAfVersion}](https://www.nuget.org/packages/LinqAF/{linqAfVersion})");

    var structLinqVersion = GetInformationalVersion(typeof(StructLinq.List.ListEnumerable<>).Assembly);
    logger.WriteLine($"- StructLinq.BCL: [{structLinqVersion}](https://www.nuget.org/packages/StructLinq/{structLinqVersion})");

    var hyperlinqVersion = GetInformationalVersion(typeof(ValueEnumerable).Assembly);
    logger.WriteLine($"- NetFabric.Hyperlinq: [{hyperlinqVersion}](https://www.nuget.org/packages/NetFabric.Hyperlinq/{hyperlinqVersion})");

    var linqAsyncVersion = GetInformationalVersion(typeof(System.Linq.AsyncEnumerable).Assembly);
    logger.WriteLine($"- System.Linq.Async: [{linqAsyncVersion}](https://www.nuget.org/packages/System.Linq.Async/{linqAsyncVersion})");

    var faslinqVersion = GetInformationalVersion(typeof(Faslinq.ArrayExtensions).Assembly);
    logger.WriteLine($"- Faslinq: [{faslinqVersion}](https://www.nuget.org/packages/Faslinq/{faslinqVersion})");

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

static T GetCustomAttribute<T>(Assembly assembly) 
    where T : Attribute
    => (T)Attribute.GetCustomAttribute(assembly, typeof(T), false);

static Type GetTargetType(Summary summary)
{
    var targetTypes = summary.BenchmarksCases.AsValueEnumerable().Select(i => i.Descriptor.Type).Distinct().ToList();
    return targetTypes.Count == 1 ? targetTypes[0] : null;
}

static string GetSolutionDirectory()
{
    var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

    while (dir is not null or {Length:0})
    {
        if (Directory.EnumerateFiles(dir, "*.sln", SearchOption.TopDirectoryOnly).Any())
            return dir;

        dir = Path.GetDirectoryName(dir);
    }

    return null;
}


using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqBenchmarks
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    //[RPlotExporter, CsvMeasurementsExporter] // requires installation of R (https://benchmarkdotnet.org/articles/configs/exporters.html#plots)
    public class BenchmarkBase

    {
        [Params(0, 1, 10, 1_000)]
        public int Count { get; set; }
    }
}

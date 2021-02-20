using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections;

namespace LinqBenchmarks
{
    //[SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    //[MarkdownExporterAttribute.GitHub]
    //[RPlotExporter, CsvMeasurementsExporter] // requires installation of R (https://benchmarkdotnet.org/articles/configs/exporters.html#plots)
    //[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.CacheMisses)]
    //[DisassemblyDiagnoser(printSource: true, maxDepth: 1)]
    public class BenchmarkBase
    {
        [Params(10, 1000)]
        public int Count { get; set; }

        protected static int[] GetSequentialValues(int count)
        {
            var array = new int[count];

            for (var index = 0; index < count; index++)
                array[index] = index;

            return array;
        }

        protected static int[] GetRandomValues(int count)
        {
            var array = new int[count];

            var random = new Random(42);
            for (var index = 0; index < count; index++)
                array[index] = random.Next(count);

            return array;
        }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using StructLinq;
using System.Buffers;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    // [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    // [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class RangeSelectBenchmarks
    {
        [Params(0)]
        public int Start { get; set; }

        [Params(100_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Range(Start, Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in StructEnumerable.Range(Start, Count).Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Range(Start, Count).Select(item => item * 2))
                sum += item;
            return sum;
        }
    }
}

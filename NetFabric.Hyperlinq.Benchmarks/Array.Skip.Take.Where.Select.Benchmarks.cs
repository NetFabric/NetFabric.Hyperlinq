using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    public class ArraySkipTakeWhereSelectBenchmarks
    {
        int[] array;

        [Params(0, 1, 10, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup() 
            => array = ValueEnumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Skip(array, 0).Take(10).Where(_ => true).Select(item => item))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in array.Skip(0).Take(10).Where(_ => true).Select(item => item))
                sum += item;
            return sum;
        }
    }
}

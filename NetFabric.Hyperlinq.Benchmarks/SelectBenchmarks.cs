using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    public class SelectBenchmarks
    {
        [Params(100, 1_000, 10_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int Linq_Select()
        {
            var sum = 0;
            foreach(var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Range(0, Count), v => v * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Select()
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count).Select(v => v * 2))
                sum += item;
            return sum;
        }   
    }
}

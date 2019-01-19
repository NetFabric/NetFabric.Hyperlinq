using BenchmarkDotNet.Attributes;
using System.Linq;

namespace NetFabric.Hyperlinq.Rewriter.Benchmarks
{
    [MemoryDiagnoser]
    public class QueryBenchmarks
    {
        [Params(100, 1_000, 10_000)]
        public int Count { get; set; }

        [Benchmark]
        public int Range()
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Range_Select()
        {
            var sum = 0;
            foreach (var item in Enumerable.Range(0, Count).Select(value => value))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Range_Where()
        {
            var sum = 0;
            foreach (var item in Enumerable.Range(0, Count).Where(_ => true))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Range_Where_Select()
        {
            var sum = 0;
            foreach (var item in Enumerable.Range(0, Count).Where(_ => true).Select(value => value))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Range_Count() => 
            Enumerable.Range(0, Count).Count();

        [Benchmark]
        public int Range_Select_Count() =>
            Enumerable.Range(0, Count).Select(value => value).Count();

        [Benchmark]
        public int Range_Where_Count() =>
            Enumerable.Range(0, Count).Where(_ => true).Count();

        [Benchmark]
        public int Range_Where_Select_Count() =>
            Enumerable.Range(0, Count).Where(_ => true).Select(value => value).Count();


        [Benchmark]
        public int Range_First() =>
            Enumerable.Range(0, Count).First();

        [Benchmark]
        public int Range_Select_First() =>
            Enumerable.Range(0, Count).Select(value => value).First();

        [Benchmark]
        public int Range_Where_First() =>
            Enumerable.Range(0, Count).Where(_ => true).First();

        [Benchmark]
        public int Range_Where_Select_First() =>
            Enumerable.Range(0, Count).Where(_ => true).Select(value => value).First();

    }
}

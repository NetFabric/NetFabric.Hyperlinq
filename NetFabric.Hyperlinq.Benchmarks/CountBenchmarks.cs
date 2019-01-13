using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    public class CountBenchmarks
    {
        int[] array;

        [Params(100, 1_000, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = System.Linq.Enumerable.ToArray(Enumerable.Range(0, Count));
        }

        [Benchmark(Baseline = true)]
        public int Linq_Array() => 
            System.Linq.Enumerable.Count(array);

        [Benchmark]
        public int Linq_Range() => 
            System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Range(0, Count));

        [Benchmark]
        public int Linq_Range_Select() => 
            System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Range(0, Count), value => value));

        [Benchmark]
        public int Linq_Range_Where() => 
            System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Where(
                    System.Linq.Enumerable.Range(0, Count), _ => true));

        [Benchmark]
        public int Hyperlinq_Array() => 
            array.Count();

        [Benchmark]
        public int Hyperlinq_Range() => 
            Enumerable.Range(0, Count)
            .Count<Enumerable.RangeEnumerable, int>();

        [Benchmark]
        public int Hyperlinq_Range_Select() => 
            Enumerable.Range(0, Count)
            .Select(value => value)
            .Count<Enumerable.SelectList<int, int>, int>();

        [Benchmark]
        public int Hyperlinq_Range_Where() => 
            Enumerable.Range(0, Count)
            .Where<Enumerable.RangeEnumerable, int>(_ => true)
            .Count<Enumerable.WhereEnumerable<int>, int>();
    }
}

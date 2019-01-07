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
        public int Linq_Array_Count() => System.Linq.Enumerable.Count(array);

        [Benchmark]
        public int Linq_Range_Count() => System.Linq.Enumerable.Count(System.Linq.Enumerable.Range(0, Count));

        [Benchmark]
        public int Linq_MyEnumerable_Count() => System.Linq.Enumerable.Count(MyEnumerable(Count));

        [Benchmark]
        public long Hyperlinq_Array_Count() => array.Count<IEnumerable<int>, int>();

        [Benchmark]
        public long Hyperlinq_Range_Count() => Enumerable.Range(0, Count).Count<Enumerable.RangeEnumerable, int>();

        [Benchmark]
        public long Hyperlinq_MyEnumerable_Count() => MyEnumerable(Count).Count<IEnumerable<int>, int>();

        static IEnumerable<int> MyEnumerable(int count)
        {
            for(var value = 0; value < count; value++)
                yield return value;
        }
    }
}

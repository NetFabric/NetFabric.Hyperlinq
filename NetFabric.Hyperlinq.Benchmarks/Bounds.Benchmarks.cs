using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class BoundsBenchmarks
    {
        int[] array;
        int[] intervalArray;
        IReadOnlyList<int> list;
        IReadOnlyList<int> intervalList;


        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = ValueEnumerable.Range(0, Count).ToArray();
            intervalArray = ValueEnumerable.Range(0, Count + 200).ToArray();
            list = ValueEnumerable.Range(0, Count).ToList();
            intervalList = ValueEnumerable.Range(0, Count + 200).ToList();
        }

        [Benchmark(Baseline = true)]
        public int Array_Property()
        {
            var total = 0;
            for (var index = 0; index < array.Length; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int Array_Variable()
        {
            var total = 0;
            var take = array.Length;
            for (var index = 0; index < take; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int IntervalArray()
        {
            var total = 0;
            var skip = 100;
            var take = array.Length - 100;
            for (var index = skip; index < take; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int List_Property()
        {
            var total = 0;
            for (var index = 0; index < list.Count; index++)
                total += list[index];
            return total;
        }

        [Benchmark]
        public int List_Variable()
        {
            var total = 0;
            var take = list.Count;
            for (var index = 0; index < take; index++)
                total += list[index];
            return total;
        }

        [Benchmark]
        public int IntervalList()
        {
            var total = 0;
            var skip = 100;
            var take = list.Count - 100;
            for (var index = skip; index < take; index++)
                total += list[index];
            return total;
        }
    }
}

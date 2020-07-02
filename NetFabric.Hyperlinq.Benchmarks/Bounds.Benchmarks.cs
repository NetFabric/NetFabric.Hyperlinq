using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class BoundsBenchmarks
    {
        int[] array;
        ArraySegment<int> arraySegment;
        List<int> list;
        ReadOnlyListSegment<List<int>, int> listSegment;

        [Params(0)]
        public int Offset { get; set; }

        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = ValueEnumerable.Range(0, Count).ToArray();
            arraySegment = new ArraySegment<int>(array, Offset, Count);
            list = ValueEnumerable.Range(0, Count).ToList();
            listSegment = new ReadOnlyListSegment<List<int>, int>(list, Offset, Count);
        }

        [Benchmark(Baseline = true)]
        public int Array()
        {
            var total = 0;
            for (var index = 0; index < array.Length; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int Array_Variables()
        {
            var total = 0;
            var end = Offset + Count;
            for (var index = Offset; index < end; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int ArraySegment()
        {
            var total = 0;
            var array = arraySegment.Array;
            for (var index = 0; index < array.Length; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int ArraySegment_Variables()
        {
            var total = 0;
            var array = arraySegment.Array;
            var end = arraySegment.Offset + arraySegment.Count;
            for (var index = arraySegment.Offset; index < end; index++)
                total += array[index];
            return total;
        }

        [Benchmark]
        public int List()
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
            var end = Offset + Count;
            for (var index = Offset; index < end; index++)
                total += list[index];
            return total;
        }

        [Benchmark]
        public int ListSegment()
        {
            var total = 0;
            var list = listSegment.List;
            for (var index = 0; index < list.Count; index++)
                total += list[index];
            return total;
        }

        [Benchmark]
        public int ListSegment_Variables()
        {
            var total = 0;
            var list = listSegment.List;
            var end = listSegment.Offset + listSegment.Count;
            for (var index = listSegment.Offset; index < end; index++)
                total += list[index];
            return total;
        }
    }

    readonly struct ReadOnlyListSegment<TList, T>
        where TList : IReadOnlyList<T>
    {
        public ReadOnlyListSegment(TList list, int offset, int count)
            => (List, Offset, Count) = (list, offset, count);

        public TList List { get; }
        public int Offset { get; }
        public int Count { get; }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class ArrayIterationBenchmarks
    {
        int[] array;
        ReadOnlyMemory<int> memory;
        ArraySegment<int> segment;
        IList<int> list;

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = Enumerable.Range(0, Count).ToArray();
            memory = array.AsMemory();
            segment = new ArraySegment<int>(array);
            list = array;
        }

        [Benchmark(Baseline = true)]
        public int Enumerator()
        {
            var sum = 0;
            foreach (var item in array)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Indexer()
        {
            var sum = 0;
            var source = array;
            for (var index = 0; index < source.Length; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int IndexerLT()
        {
            var sum = 0;
            var source = array;
            var length = source.Length;
            for (var index = 0; index < length; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int IndexerLTE()
        {
            var sum = 0;
            var source = array;
            var end = source.Length - 1;
            for (var index = 0; index <= end; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int ArraySpan()
        {
            var sum = 0;
            var source = array.AsSpan();
            for (var index = 0; index < source.Length; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int MemorySpan()
        {
            var sum = 0;
            var source = memory.Span;
            for (var index = 0; index < source.Length; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int Memory()
        {
            var sum = 0;
            var source = memory;
            for (var index = 0; index < source.Length; index++)
                sum += source.Span[index];
            return sum;
        }

        [Benchmark]
        public int ArraySegment_Enumerator()
        {
            var sum = 0;
            foreach (var item in segment)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int ArraySegment_Indexer()
        {
            var sum = 0;
            var source = segment.Array;
            for (var index = 0; index < source.Length; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int IEnumerable_Enumerator()
        {
            var sum = 0;
            foreach (var item in list)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int IList_Indexer()
        {
            var sum = 0;
            var source = list;
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }
    }
}

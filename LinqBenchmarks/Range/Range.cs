
using BenchmarkDotNet.Attributes;
using JM.LinqFaster.SIMD;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Range
{
    public class Range: RangeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Start + Count;
            for (var value = Start; value < end; value++)
                sum += value;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var items = System.Linq.Enumerable.Range(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster_SIMD()
        {
            var items = LinqFasterSIMD.RangeS(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var items = global::LinqAF.Enumerable.Range(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var items = StructEnumerable.Range(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq()
        {
            var items = ValueEnumerable.Range(Start, Count);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.
    }
}


using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Range
{
    public class RangeSelect: RangeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Start + Count;
            for (var value = Start; value < end; value++)
                sum += value * 2;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var value in Range(Start, Count))
                sum += value * 2;
            return sum;

            static IEnumerable<int> Range(int start, int count)
            {
                var end = start + count;
                for (var value = start; value < end; value++)
                    yield return value;
            }
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Range(Start, Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count).SelectF(item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.Enumerable.Range(Start, Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in StructEnumerable
                .Range(Start, Count)
                .Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new DoubleOfInt32();
            foreach (var item in StructEnumerable
                .Range(Start, Count)
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Range(Start, Count).Select(item => item * 2))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.
    }
}

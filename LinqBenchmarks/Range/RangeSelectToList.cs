
using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Range
{
    public partial class RangeSelectToList: RangeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < Count; index++)
                list.Add((index + Start) * 3);
            return list;
        }

        [Benchmark]
        public List<int> ForeachLoop()
        {
            var list = new List<int>();
            foreach (var value in Range(Start, Count))
                list.Add(value * 3);
            return list;

            static IEnumerable<int> Range(int start, int count)
            {
                var end = start + count;
                for (var value = start; value < end; value++)
                    yield return value;
            }
        }

        [Benchmark]
        public List<int> Linq()
            => System.Linq.Enumerable.Range(Start, Count).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new(JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count).SelectF(item => item * 3));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.Enumerable.Range(Start, Count).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> StructLinq()
            => StructEnumerable
                .Range(Start, Count)
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var selector = new TripleOfInt32();
            return StructEnumerable
                .Range(Start, Count)
                .Select(ref selector, x => x, x => x)
                .ToList(x => x);
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => ValueEnumerable
                .Range(Start, Count)
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction()
            => ValueEnumerable
                .Range(Start, Count)
                .Select<int, TripleOfInt32>()
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_SIMD()
            => ValueEnumerable
                .Range(Start, Count)
                .SelectVector(item => item * 3, item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction_SIMD()
            => ValueEnumerable
                .Range(Start, Count)
                .SelectVector<int, TripleOfInt32>()
                .ToList();
    }
}

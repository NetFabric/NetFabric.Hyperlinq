using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.ImmutableArray.Int32
{
    public class ImmutableArrayInt32SkipTakeSelect: ImmutableArrayInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += source[index] * 3;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            using var enumerator = ((IEnumerable<int>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 3;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Skip(Skip).Take(Count).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqOptimizer()
        {
            var sum = 0;
            foreach (var item in source
                .AsQueryExpr()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3)
                .Run())
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Streams()
        {
            var sum = 0;
            foreach (var item in source
                .AsStream()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3)
                .ToEnumerable())
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new TripleOfInt32();
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=> x)
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Foreach_IFunction()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select<int, TripleOfInt32>())
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var sum = 0;
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_For_IFunction()
        {
            var sum = 0;
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select<int, TripleOfInt32>();
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

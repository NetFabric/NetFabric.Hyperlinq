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
            var items = source.Skip(Skip).Take(Count).Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqOptimizer()
        {
            var items = source
                .AsQueryExpr()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3)
                .Run();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Streams()
        {
            var items = source
                .AsStream()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3)
                .ToEnumerable();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var items = source
                .ToStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var selector = new TripleOfInt32();
            var items = source
                .ToStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=> x)
                .Select(ref selector, x => x, x => x);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
        {
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select<int, TripleOfInt32>();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}

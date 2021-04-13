using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeSkipTakeSelect: ValueTypeListSkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += source[index] * 3;
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            using var enumerator = ((IEnumerable<FatValueType>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = default(FatValueType);
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 3;
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).SelectF(item => item * 3);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ListExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqOptimizer()
        {
            var sum = default(FatValueType);
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
        public FatValueType Streams()
        {
            var sum = default(FatValueType);
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
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .ToRefStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select((in FatValueType item) => item * 3))
                sum += item;
            return sum;
        }


        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var selector = new TripleOfFatValueType();

            foreach (var item in source
                .ToRefStructEnumerable()
                .Skip(Skip, x => x)
                .Take(Count, x => x)
                .Select(ref selector, x=> x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType Hyperlinq_Foreach()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_Foreach_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
              .Skip(Skip)
              .Take(Count)
              .Select<FatValueType, TripleOfFatValueType>())
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Hyperlinq_For()
        {
            var sum = default(FatValueType);
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 3);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_For_IFunction()
        {
            var sum = default(FatValueType);
            var items = source.AsValueEnumerable()
              .Skip(Skip)
              .Take(Count)
              .Select<FatValueType, TripleOfFatValueType>();
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

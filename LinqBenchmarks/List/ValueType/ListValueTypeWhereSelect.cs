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
    public class ListValueTypeWhereSelect: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += (item * 3);
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (item.IsEven())
                    sum += (item * 3);
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Where(source, item => item.IsEven()).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.WhereSelectF(item => item.IsEven(), item => item * 3);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqOptimizer()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .AsQueryExpr()
                .Where(item => item.IsEven())
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
                .Where(item => item.IsEven())
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
                .Where((in FatValueType item) => item.IsEven())
                .Select((in FatValueType item) => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var predicate = new FatValueTypeIsEven();
            var selector = new TripleOfFatValueType();
            foreach (var item in source
                .ToRefStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Where<FatValueTypeIsEven>()
                .Select<FatValueType, TripleOfFatValueType>())
                sum += item;
            return sum;
        }
    }
}

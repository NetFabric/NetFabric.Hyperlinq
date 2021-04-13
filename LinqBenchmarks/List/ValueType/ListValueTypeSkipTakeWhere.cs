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
    public class ListValueTypeSkipTakeWhere: ValueTypeListSkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
            }
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
            {
                var item = enumerator.Current;
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).WhereF(item => item.IsEven());
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ListExtensionMethods.Skip(source, Skip).Take(Count).Where(item => item.IsEven()))
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
                .Where(item => item.IsEven())
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
                .Where(item => item.IsEven())
                .ToEnumerable())
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (ref var item in source
                .ToRefStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where((in FatValueType item) => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var predicate = new FatValueTypeIsEven();

            foreach (ref readonly var item in source
                .ToRefStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=> x)
                .Where(ref predicate, x=> x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where<FatValueTypeIsEven>())
                sum += item;
            return sum;
        }
    }
}

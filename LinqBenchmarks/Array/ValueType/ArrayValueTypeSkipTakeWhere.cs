using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using LinqFasterer;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSkipTakeWhere: ValueTypeArraySkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                ref readonly var item = ref source[index];
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
            var items = System.Linq.Enumerable.Skip(source, Skip).Take(Count).Where(item => item.IsEven());
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).WhereF(item => item.IsEven());
            var sum = default(FatValueType);
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFasterer()
        {
            var items = EnumerableF.WhereF(EnumerableF.TakeF(EnumerableF.SkipF(source, Skip), Count), item => item.IsEven());
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var items = global::LinqAF.ArrayExtensionMethods.Skip(source, Skip).Take(Count).Where(item => item.IsEven());
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqOptimizer()
        {
            var items = source
                .AsQueryExpr()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven())
                .Run();
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Streams()
        {
            var items = source
                .AsStream()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven())
                .ToEnumerable();
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var items = source
                .ToRefStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where((in FatValueType item) => item.IsEven());
            var sum = default(FatValueType);
            foreach (ref readonly var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_ValueDelegate()
        {
            var predicate = new FatValueTypeIsEven();
            var items = source
                .ToRefStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=> x)
                .Where(ref predicate, x=> x);
            var sum = default(FatValueType);
            foreach (ref readonly var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var arraySegmentWhereEnumerable = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven());
            var sum = default(FatValueType);
            foreach (var item in arraySegmentWhereEnumerable)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_ValueDelegate()
        {
            var arraySegmentWhereEnumerable = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where<FatValueTypeIsEven>();
            var sum = default(FatValueType);
            foreach (var item in arraySegmentWhereEnumerable)
                sum += item;
            return sum;
        }
    }
}

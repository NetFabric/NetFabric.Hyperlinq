using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using LinqFasterer;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeDistinct: BenchmarkBase
    {
        List<FatValueType> source;
        List<FatValueType> sourceLinqFaster;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var items = System.Linq.Enumerable
                .SelectMany(
                    System.Linq.Enumerable.Range(0, Duplicates),
                    _ => System.Linq.Enumerable.Range(0, Count)
                        .Select(value => new FatValueType(value)));

            source = items.ToList();
            sourceLinqFaster = items.ToList();
        }

        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Linq()
        {
            var items = System.Linq.Enumerable.Distinct(source);
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            if (Count is not 0)
                sourceLinqFaster.DistinctInPlaceF(new FatValueTypeEqualityComparer());
            var sum = default(FatValueType);
            foreach (var item in sourceLinqFaster)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFasterer()
        {
            var items = EnumerableF.DistinctF(source);
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var items = global::LinqAF.ListExtensionMethods.Distinct(source);
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
                .Distinct();
            var sum = default(FatValueType);
            foreach (ref readonly  var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_ValueDelegate()
        {
            var comparer = new FatValueTypeEqualityComparer();
            var items = source
                .ToRefStructEnumerable()
                .Distinct(comparer, x=> x);
            var sum = default(FatValueType);
            foreach (ref readonly  var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var items = source.AsValueEnumerable().Distinct();
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}

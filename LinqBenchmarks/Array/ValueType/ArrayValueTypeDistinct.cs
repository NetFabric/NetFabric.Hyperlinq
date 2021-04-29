using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using LinqFasterer;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeDistinct: BenchmarkBase
    {
        FatValueType[] source;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = System.Linq.Enumerable
                .SelectMany(
                    System.Linq.Enumerable.Range(0, Duplicates), 
                    _ => System.Linq.Enumerable.Range(0, Count)
                        .Select(value => new FatValueType(value)))
                .ToArray();

        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

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
            var items = global::LinqAF.ArrayExtensionMethods.Distinct(source);
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
            foreach (ref readonly var item in items)
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
            var items = source.AsValueEnumerable()
                .Distinct();
            var sum = default(FatValueType);
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}

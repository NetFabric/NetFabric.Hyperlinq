using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeDistinct: BenchmarkBase
    {
        List<FatValueType> source;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup() 
            => source = Enumerable
                .SelectMany(
                    Enumerable.Range(0, Duplicates), 
                    _ => Enumerable.Range(0, Count / Duplicates)
                        .Select(value => new FatValueType(value)))
                .ToList();

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
            var sum = default(FatValueType);
            foreach (var item in Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            JM.LinqFaster.LinqFaster.DistinctInPlaceF(source, new FatValueTypeEqualityComparer());
            var sum = default(FatValueType);
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (ref readonly  var item in source.ToRefStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var comparer = new FatValueTypeEqualityComparer();
            foreach (var item in source.ToStructEnumerable().Distinct(comparer, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in ListBindings.Distinct(source))
                sum += item;
            return sum;
        }
    }
}

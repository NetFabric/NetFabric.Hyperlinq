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
        public int ForLoop()
        {
            var set = new HashSet<int>();
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (set.Add(item.Value0))
                    sum += item.Value0;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int ForeachLoop()
        {
            var set = new HashSet<int>();
            var sum = 0;
            foreach (var item in source)
            {
                if (set.Add(item.Value0))
                    sum += item.Value0;
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(source))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            JM.LinqFaster.LinqFaster.DistinctInPlaceF(source, new FatValueTypeEqualityComparer());
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index].Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (ref var item in source.ToRefStructEnumerable().Distinct(x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var comparer = new FatValueTypeEqualityComparer();
            foreach (var item in source.ToStructEnumerable().Distinct(comparer, x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ListBindings.Distinct(source))
                sum += item.Value0;
            return sum;
        }
    }
}

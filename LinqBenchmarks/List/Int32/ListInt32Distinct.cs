using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.Int32
{
    public class ListInt32Distinct: BenchmarkBase
    {
        List<int> source;
        List<int> sourceLinqFaster;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var items = System.Linq.Enumerable
                .SelectMany(
                    System.Linq.Enumerable.Range(0, Duplicates),
                    _ => System.Linq.Enumerable.Range(0, Count));

            source = items.ToList();
            sourceLinqFaster = items.ToList();
        }

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var set = new HashSet<int>();
            var sum = 0;
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
        public int ForeachLoop()
        {
            var set = new HashSet<int>();
            var sum = 0;
            foreach (var item in source)
            {
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            if (Count != 0)
                sourceLinqFaster.DistinctInPlaceF();
            var sum = 0;
            for (var index = 0; index < sourceLinqFaster.Count; index++)
                sum += sourceLinqFaster[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var comparer = new IntEqualityComparer();
            foreach (var item in source.ToStructEnumerable().Distinct(comparer, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ListBindings.Distinct(source))
                sum += item;
            return sum;
        }
    }
}

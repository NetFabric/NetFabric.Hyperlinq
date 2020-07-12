using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ListDistinct : BenchmarkBase
    {
        List<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToList();

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
            foreach (var item in Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            JM.LinqFaster.LinqFaster.DistinctInPlaceF(source);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
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
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ListBindings.Distinct(source))
                sum += item;
            return sum;
        }
    }
}

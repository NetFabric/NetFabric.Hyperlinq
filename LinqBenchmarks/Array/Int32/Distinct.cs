using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32Distinct : BenchmarkBase
    {
        int[] source;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable
                .SelectMany(
                    Enumerable.Range(0, Duplicates),
                    _ => Enumerable.Range(0, Count / Duplicates))
                .ToArray();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var set = new HashSet<int>();
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

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

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public int LinqFaster()
        //{
        //    JM.LinqFaster.LinqFaster.DistinctInPlaceF(source);
        //    var sum = 0;
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

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
            foreach (var item in ArrayExtensions.Distinct(source))
                sum += item;
            return sum;
        }
    }
}

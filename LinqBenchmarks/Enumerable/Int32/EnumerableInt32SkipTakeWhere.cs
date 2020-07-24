using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    [BenchmarkCategory("Enumerable", "Int32")]
    public class EnumerableInt32SkipTakeWhere: EnumerableInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            using var enumerator = source.GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
            {
                var item = enumerator.Current;
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Skip(Skip).Take(Count).Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in source.Skip(Skip).Take(Count).Where(item => item.IsEven()))
                sum += item;
            return sum;
        }
    }
}

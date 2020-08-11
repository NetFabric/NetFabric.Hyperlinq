
using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Range
{
    public class RangeToList: RangeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < Count; index++)
                list.Add(index + Start);
            return list;
        }

        [Benchmark]
        public List<int> ForeachLoop()
        {
            var list = new List<int>();
            foreach (var value in Range(Start, Count))
                list.Add(value);
            return list;

            static IEnumerable<int> Range(int start, int count)
            {
                var end = start + count;
                for (var value = start; value < end; value++)
                    yield return value;
            }
        }

        [Benchmark]
        public List<int> Linq()
            => System.Linq.Enumerable.Range(Start, Count).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.Enumerable.Range(Start, Count).ToList();

        [Benchmark]
        public List<int> StructLinq()
            => StructEnumerable.Range(Start, Count).ToList();

        [Benchmark]
        public List<int> Hyperlinq()
            => ValueEnumerable.Range(Start, Count).ToList();
    }
}

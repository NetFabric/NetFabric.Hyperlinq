
using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class RangeToList : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }


        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < Count; index++)
                list.Add(index + Start);
            return list;
        }

        [Benchmark]
        public List<int> Linq()
            => Enumerable.Range(Start, Count).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count));

        [Benchmark]
        public List<int> StructLinq()
            => StructEnumerable.Range(Start, Count).ToList();

        [Benchmark]
        public List<int> Hyperlinq()
            => ValueEnumerable.Range(Start, Count).ToList();
    }
}

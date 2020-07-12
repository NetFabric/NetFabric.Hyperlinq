
using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class RangeSelectToList : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }


        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < Count; index++)
                list.Add((index + Start) * 2);
            return list;
        }

        [Benchmark]
        public List<int> Linq()
            => Enumerable.Range(Start, Count).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count).SelectF(item => item * 2));

        [Benchmark]
        public List<int> StructLinq()
            => StructEnumerable.Range(Start, Count).Select(item => item * 2, x => x).ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var mult = new DoubleFunction();
            return StructEnumerable.Range(Start, Count).Select(ref mult, x => x, x => x).ToList();
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => ValueEnumerable.Range(Start, Count).Select(item => item * 2).ToList();
    }
}

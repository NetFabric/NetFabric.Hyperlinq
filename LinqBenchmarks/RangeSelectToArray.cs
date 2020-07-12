
using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks
{
    public class RangeSelectToArray : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }


        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var array = new int[Count];
            for (var index = 0; index < Count; index++)
                array[index] = (index + Start) * 2;
            return array;
        }

        [Benchmark]
        public int[] Linq()
            => Enumerable.Range(Start, Count).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count).SelectF(item => item * 2);

        [Benchmark]
        public int[] StructLinq()
            => StructEnumerable.Range(Start, Count).Select(item => item * 2, x => x).ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var mult = new DoubleFunction();
            return StructEnumerable.Range(Start, Count).Select(ref mult, x => x, x => x).ToArray();
        }

        [Benchmark]
        public int[] Hyperlinq()
            => ValueEnumerable.Range(Start, Count).Select(item => item * 2).ToArray();
    }
}

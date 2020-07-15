
using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Linq;

namespace LinqBenchmarks
{
    public class RangeToArray : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }


        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var array = new int[Count];
            for (var index = 0; index < Count; index++)
                array[index] = index + Start;
            return array;
        }

        [Benchmark]
        public int[] Linq()
            => Enumerable.Range(Start, Count).ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count);

        [Benchmark]
        public int[] StructLinq()
            => StructEnumerable.Range(Start, Count).ToArray();

        [Benchmark]
        public int[] Hyperlinq()
            => ValueEnumerable.Range(Start, Count).ToArray();

        [Benchmark]
        public int Hyperlinq_Pool()
        {
            using var array = ValueEnumerable.Range(Start, Count).ToArray(MemoryPool<int>.Shared);
            return array.Memory.Span[0];
        }
    }
}

using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32WhereSelectToArray: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int[] ForeachLoop()
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list.ToArray();
        }

        [Benchmark]
        public int[] Linq()
            => source.Where(item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x).ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            return source.ToStructEnumerable().Where(ref predicate, x => x).Select(ref selector, x => x, x => x).ToArray();
        }

        [Benchmark]
        public int[] Hyperlinq()
            => source.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int Hyperlinq_Pool()
        {
            using var array = source.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item * 2).ToArray(MemoryPool<int>.Shared);
            return Count == 0 ? default : array.Memory.Span[0];
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.Int32
{
    public class ListInt32WhereSelectToArray: Int32ListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list.ToArray();
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
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
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int[] Linq()
            => System.Linq.Enumerable
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => source
                .WhereSelectF(item => item.IsEven(), item => item * 2)
                .ToArray();

        [Benchmark]
        public int[] LinqAF()
            => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToArray(x=>x);
        }

        [Benchmark]
        public int[] Hyperlinq()
            => ListBindings
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public int[] Hyperlinq_IFunction()
            => ListBindings
                .Where<int, Int32IsEven>(source)
                .Select<int, DoubleOfInt32>()
                .ToArray();

        [Benchmark]
        public int Hyperlinq_Pool()
        {
            using var array = ListBindings
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray(MemoryPool<int>.Shared);
            return Count == 0 ? default : array.Memory.Span[0];
        }

        [Benchmark]
        public int Hyperlinq_Pool_IFunction()
        {
            using var array = ListBindings
                .Where<int, Int32IsEven>(source)
                .Select<int, DoubleOfInt32>()
                .ToArray(MemoryPool<int>.Shared);
            return Count == 0 ? default : array.Memory.Span[0];
        }
    }
}

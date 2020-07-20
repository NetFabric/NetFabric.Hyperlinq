using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.ValueType.Array
{
    public class ArrayWhereSelectToArray : BenchmarkBase
    {
        int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list.ToArray();
        }

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

        [Benchmark]
        public int[] Linq()
            => Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => JM.LinqFaster.LinqFaster.WhereSelectF(source, item => item.IsEven(), item => item * 2);

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x).ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var where = new IsEvenFunction();
            var mult = new DoubleFunction();
            return source.ToStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x).ToArray();
        }

        [Benchmark]
        public int[] Hyperlinq()
            => ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public int Hyperlinq_Pool()
        {
            using var array = ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray(MemoryPool<int>.Shared);
            return array.Memory.Span[0];
        }
    }
}

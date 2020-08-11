using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhereSelectToArray: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType[] ForLoop()
        {
            var list = new List<FatValueType>();
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list.ToArray();
        }

        [Benchmark]
        public FatValueType[] ForeachLoop()
        {
            var list = new List<FatValueType>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list.ToArray();
        }

        [Benchmark]
        public FatValueType[] Linq()
            => System.Linq.Enumerable
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] LinqFaster()
            => source
                .WhereSelectF(item => item.IsEven(), item => item * 2);

        [Benchmark]
        public FatValueType[] LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2).ToArray();

        [Benchmark]
        public FatValueType[] StructLinq()
            => source
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .Select(item => item * 2, x => x)
                .ToArray();

        [Benchmark]
        public FatValueType[] StructLinq_IFunction()
        {
            var predicate = new FatValueTypeIsEven();
            var selector = new DoubleOfFatValueType();
            return source.ToRefStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToArray();
        }

        [Benchmark]
        public FatValueType[] Hyperlinq()
            => ArrayExtensions
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType Hyperlinq_Pool()
        {
            using var array = ArrayExtensions
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray(MemoryPool<FatValueType>.Shared);
            return Count == 0 
                ? default 
                : array.Memory.Span[0];
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeWhereSelectToArray: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType[] ForLoop()
        {
            var list = new List<FatValueType>();
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
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType[] Linq()
            => System.Linq.Enumerable
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] LinqFaster()
            => source
                .WhereSelectF(item => item.IsEven(), item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] LinqAF()
            => global::LinqAF.ListExtensionMethods
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] StructLinq()
            => source
                .ToRefStructEnumerable()
                .Where((in FatValueType item) => item.IsEven())
                .Select((in FatValueType item) => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] StructLinq_IFunction()
        {
            var predicate = new FatValueTypeIsEven();
            var selector = new DoubleOfFatValueType();
            return source.ToRefStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToArray(x=> x);
        }

        [Benchmark]
        public FatValueType[] Hyperlinq()
            => ListBindings
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] Hyperlinq_IFunction()
            => ListBindings
                .Where<FatValueType, FatValueTypeIsEven>(source)
                .Select<FatValueType, DoubleOfFatValueType>()
                .ToArray();

        [Benchmark]
        public FatValueType Hyperlinq_Pool()
        {
            using var array = ListBindings
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray(MemoryPool<FatValueType>.Shared);
            return Count == 0 ? default : array.Memory.Span[0];
        }

        [Benchmark]
        public FatValueType Hyperlinq_Pool_IFunction()
        {
            using var array = ListBindings
                .Where<FatValueType, FatValueTypeIsEven>(source)
                .Select<FatValueType, DoubleOfFatValueType>()
                .ToArray(MemoryPool<FatValueType>.Shared);
            return Count == 0 ? default : array.Memory.Span[0];
        }
    }
}

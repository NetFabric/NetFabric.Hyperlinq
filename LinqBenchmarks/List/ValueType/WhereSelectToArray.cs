using BenchmarkDotNet.Attributes;
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
                if (item.Value0.IsEven())
                    list.Add(new FatValueType(item.Value0 * 2));
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
                if (item.Value0.IsEven())
                    list.Add(new FatValueType(item.Value0 * 2));
            }
            return list.ToArray();
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType[] Linq()
            => Enumerable
                .Where(source, item => item.Value0.IsEven())
                .Select(item => new FatValueType(item.Value0 * 2))
                .ToArray();

        [Benchmark]
        public FatValueType[] LinqFaster()
            => JM.LinqFaster.LinqFaster
                .WhereSelectF(source, item => item.Value0.IsEven(), item => new FatValueType(item.Value0 * 2))
                .ToArray();

        [Benchmark]
        public FatValueType[] StructLinq()
            => source.ToStructEnumerable()
                .Where(item => item.Value0.IsEven(), x => x)
                .Select(item => new FatValueType(item.Value0 * 2), x => x)
                .ToArray();

        [Benchmark]
        public FatValueType[] StructLinq_IFunction()
        {
            var where = new FatValueTypeIsEven();
            var mult = new DoubleOfFatValueType();
            return source.ToRefStructEnumerable()
                .Where(ref where, x => x)
                .Select(ref mult, x => x, x => x)
                .ToArray();
        }

        [Benchmark]
        public FatValueType[] Hyperlinq()
            => ListBindings
                .Where(source, item => item.Value0.IsEven())
                .Select(item => new FatValueType(item.Value0 * 2))
                .ToArray();

        [Benchmark]
        public FatValueType Hyperlinq_Pool()
        {
            using var array = ListBindings
                .Where(source, item => item.Value0.IsEven())
                .Select(item => new FatValueType(item.Value0 * 2))
                .ToArray(MemoryPool<FatValueType>.Shared);
            return array.Memory.Span[0];
        }
    }
}

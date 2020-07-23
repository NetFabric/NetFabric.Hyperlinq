using BenchmarkDotNet.Attributes;
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
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly  var item = ref source[index];
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
            => Enumerable
                .Where(source, item => item.IsEven())
                .Select(item => item * 2)
                .ToArray();

        [Benchmark]
        public FatValueType[] LinqFaster()
            => JM.LinqFaster.LinqFaster
                .WhereSelectF(source, item => item.IsEven(), item => item * 2);

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
            var where = new FatValueTypeIsEven();
            var mult = new DoubleOfFatValueType();
            return source.ToRefStructEnumerable()
                .Where(ref where, x => x)
                .Select(ref mult, x => x, x => x)
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
            return Count == 0 ? default : array.Memory.Span[0];
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeWhereSelect: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.Value0.IsEven())
                    sum += new FatValueType(item.Value0 * 2).Value0;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                if (item.Value0.IsEven())
                    sum += new FatValueType(item.Value0 * 2).Value0;
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(source, item => item.Value0.IsEven()).Select(item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.WhereSelectF(item => item.Value0.IsEven(), item => new FatValueType(item.Value0 * 2));
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index].Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Where(item => item.Value0.IsEven(), x => x).Select(item => new FatValueType(item.Value0 * 2), x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var where = new FatValueTypeIsEven();
            var mult = new DoubleOfFatValueType();
            foreach (var item in source.ToRefStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ListBindings.Where(source, item => item.Value0.IsEven()).Select(item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeWhere: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.WhereF(item => item.IsEven());
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source.ToStructEnumerable().Where(item => item.IsEven(), x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var predicate = new FatValueTypeIsEven();
            foreach (ref var item in source.ToRefStructEnumerable().Where(ref predicate, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (ref readonly  var item in ListBindings.WhereRef(source, item => item.IsEven()))
                sum += item;
            return sum;
        }
    }
}

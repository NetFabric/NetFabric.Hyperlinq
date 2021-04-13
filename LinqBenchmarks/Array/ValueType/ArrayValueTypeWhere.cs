using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhere: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

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
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqOptimizer()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .AsQueryExpr()
                .Where(item => item.IsEven())
                .Run())
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Streams()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .AsStream()
                .Where(item => item.IsEven())
                .ToEnumerable())
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (ref readonly var item in source
                .ToRefStructEnumerable()
                .Where((in FatValueType item) => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var predicate = new FatValueTypeIsEven();
            foreach (ref readonly var item in source
                .ToRefStructEnumerable()
                .Where(ref predicate, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Where<FatValueTypeIsEven>())
                sum += item;
            return sum;
        }
    }
}

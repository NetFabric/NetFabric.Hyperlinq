using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSelect: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                sum += item * 3;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var sum = default(FatValueType);
            foreach (var item in source)
                sum += item * 3;
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Select(source, item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SelectF(item => item * 3);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Select(source, item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqOptimizer()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .AsQueryExpr()
                .Select(item => item * 3)
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
                .Select(item => item * 3)
                .ToEnumerable())
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .ToRefStructEnumerable()
                .Select((in FatValueType item) => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var selector = new TripleOfFatValueType();
            foreach (var item in source
                .ToRefStructEnumerable()
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType Hyperlinq_Foreach()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_Foreach_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in source.AsValueEnumerable()
                .Select<FatValueType, TripleOfFatValueType>())
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Hyperlinq_For()
        {
            var items = source.AsValueEnumerable()
                .Select(item => item * 3);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_For_IFunction()
        {
            var items = source.AsValueEnumerable()
                .Select<FatValueType, TripleOfFatValueType>();
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

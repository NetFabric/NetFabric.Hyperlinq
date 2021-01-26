using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
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
                sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var sum = default(FatValueType);
            foreach (var item in source)
                sum += item * 2;
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SelectF(item => item * 2);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType LinqAF()
        {
            var sum = default(FatValueType);
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source
                .ToRefStructEnumerable()
                .Select((in FatValueType x) => x * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var selector = new DoubleOfFatValueType();
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
            foreach (var item in ArrayExtensions.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_Foreach_IFunction()
        {
            var sum = default(FatValueType);
            foreach (var item in ArrayExtensions.Select<FatValueType, FatValueType, DoubleOfFatValueType>(source))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Hyperlinq_For()
        {
            var items = ArrayExtensions.Select(source, item => item * 2);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq_For_IFunction()
        {
            var items = ArrayExtensions.Select<FatValueType, FatValueType, DoubleOfFatValueType>(source);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32Select: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
                sum += array[index] * 2;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item * 2;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.SelectF(item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new DoubleOfInt32();
            foreach (var item in source.ToStructEnumerable().Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Select(source, item => item * 2))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var items = ArrayExtensions.Select(source, item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32SkipTakeSelect: ArrayInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += source[index] * 2;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            using var enumerator = ((IEnumerable<int>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 2;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).SelectF(item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new DoubleOfInt32();
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=> x)
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Foreach_IFunction()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Skip(source, Skip).Take(Count).Select<int, int, DoubleOfInt32>())
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var sum = 0;
            var items = ArrayExtensions.Skip(source, Skip).Take(Count).Select(item => item * 2);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_For_IFunction()
        {
            var sum = 0;
            var items = ArrayExtensions.Skip(source, Skip).Take(Count).Select<int, int, DoubleOfInt32>();
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

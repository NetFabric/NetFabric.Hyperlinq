using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.ValueType.Array
{
    public class ArraySkipTakeSelect : BenchmarkBase
    {
        int[] source;

        [Params(1_000)]
        public int Skip { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Skip + Count).ToArray();

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
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.SelectF(source.AsSpan().Slice(Skip, Count), item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        //[Benchmark]
        //public int StructLinq()
        //{
        //    var sum = 0;
        //    foreach (var item in source.ToStructEnumerable().Select(item => item * 2, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq_IFunction()
        //{
        //    var sum = 0;
        //    var mult = new DoubleFunction();
        //    foreach (var item in source.ToStructEnumerable().Select(ref mult, x => x))
        //        sum += item;
        //    return sum;
        //}

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Skip(source, Skip).Take(Count).Select(item => item * 2))
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
    }
}

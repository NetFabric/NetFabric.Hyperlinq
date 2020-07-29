using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSkipTakeSelect: ValueTypeArraySkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                ref readonly var item = ref source[index];
                sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            using var enumerator = ((IEnumerable<FatValueType>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = default(FatValueType);
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 2;
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).SelectF(item => item * 2);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).ToStructEnumerable().Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public FatValueType StructLinq_IFunction()
        //{
        //    var sum = default(FatValueType);
        //    var selector = new DoubleOfFatValueType();
        //    foreach (var item in System.Linq.Enumerable.Skip(source, Skip).Take(Count).ToStructEnumerable().Select(ref selector, x => x, x => x))
        //        sum += item;
        //    return sum;
        //}

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType Hyperlinq_Foreach()
        {
            var sum = default(FatValueType);
            foreach (var item in ArrayExtensions.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Hyperlinq_For()
        {
            var sum = default(FatValueType);
            var items = ArrayExtensions.Skip(source, Skip).Take(Count).Select(item => item * 2);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

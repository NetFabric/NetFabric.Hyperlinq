using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeSkipTakeSelect: ValueTypeListSkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += source[index] * 2;
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
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public FatValueType LinqFaster()
        //{
        //    var items = JM.LinqFaster.LinqFaster.SelectF(source, item => item * 2);
        //    var sum = default(FatValueType);
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

        //[Benchmark]
        //public FatValueType StructLinq()
        //{
        //    var sum = default(FatValueType);
        //    foreach (var item in source.ToStructEnumerable().Select(item => item * 2, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[Benchmark]
        //public FatValueType StructLinq_IFunction()
        //{
        //    var sum = default(FatValueType);
        //    var selector = new DoubleFunction();
        //    foreach (var item in source.ToStructEnumerable().Select(ref selector, x => x))
        //        sum += item;
        //    return sum;
        //}

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public FatValueType Hyperlinq_Foreach()
        {
            var sum = default(FatValueType);
            foreach (var item in ListBindings.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public FatValueType Hyperlinq_For()
        {
            var sum = default(FatValueType);
            var items = ListBindings.Skip(source, Skip).Take(Count).Select(item => item * 2);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }
    }
}

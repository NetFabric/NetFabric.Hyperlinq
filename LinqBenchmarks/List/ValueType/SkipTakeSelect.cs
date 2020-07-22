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
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += new FatValueType(source[index].Value0 * 2).Value0;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            using var enumerator = ((IEnumerable<FatValueType>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += new FatValueType(enumerator.Current.Value0 * 2).Value0;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Select(item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }

        //[Benchmark]
        //public int LinqFaster()
        //{
        //    var items = JM.LinqFaster.LinqFaster.SelectF(source, item => new FatValueType(item.Value0 * 2));
        //    var sum = 0;
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index].Value0;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq()
        //{
        //    var sum = 0;
        //    foreach (var item in source.ToStructEnumerable().Select(item => new FatValueType(item.Value0 * 2), x => x))
        //        sum += item.Value0;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq_IFunction()
        //{
        //    var sum = 0;
        //    var mult = new DoubleFunction();
        //    foreach (var item in source.ToStructEnumerable().Select(ref mult, x => x))
        //        sum += item.Value0;
        //    return sum;
        //}

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in ListBindings.Skip(source, Skip).Take(Count).Select(item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var sum = 0;
            var items = ListBindings.Skip(source, Skip).Take(Count).Select(item => new FatValueType(item.Value0 * 2));
            for (var index = 0; index < items.Count; index++)
                sum += items[index].Value0;
            return sum;
        }
    }
}

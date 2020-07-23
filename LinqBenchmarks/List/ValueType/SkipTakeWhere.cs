using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeSkipTakeWhere: ValueTypeListSkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
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
            {
                var item = enumerator.Current;
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public FatValueType LinqFaster()
        //{
        //    var items = JM.LinqFaster.LinqFaster.WhereF(source, item => item.IsEven());
        //    var sum = default(FatValueType);
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

        //[Benchmark]
        //public FatValueType StructLinq()
        //{
        //    var sum = default(FatValueType);
        //    foreach (var item in source.ToStructEnumerable().Where(item => item.IsEven(), x => x))
        //        sum += item;
        //    return sum;
        //}

        //[Benchmark]
        //public FatValueType StructLinq_IFunction()
        //{
        //    var sum = default(FatValueType);
        //    var where = new IsEvenFunction();
        //    foreach (var item in source.ToStructEnumerable().Where(ref where, x => x))
        //        sum += item;
        //    return sum;
        //}

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in ListBindings.Skip(source, Skip).Take(Count).Where(item => item.IsEven()))
                sum += item;
            return sum;
        }
    }
}

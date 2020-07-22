using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSkipTakeWhere: ValueTypeArraySkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                var item = source[index];
                if (item.Value0.IsEven())
                    sum += item.Value0;
            }
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
            {
                var item = enumerator.Current;
                if (item.Value0.IsEven())
                    sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Where(item => item.Value0.IsEven()))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereF(source.AsSpan().Slice(Skip, Count), item => item.Value0.IsEven());
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index].Value0;
            return sum;
        }

        //[Benchmark]
        //public int StructLinq()
        //{
        //    var sum = 0;
        //    foreach (var item in source.ToStructEnumerable().Where(item => item.Value0.IsEven(), x => x))
        //        sum += item.Value0;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq_IFunction()
        //{
        //    var sum = 0;
        //    var where = new IsEvenFunction();
        //    foreach (var item in source.ToStructEnumerable().Where(ref where, x => x))
        //        sum += item.Value0;
        //    return sum;
        //}

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Skip(source, Skip).Take(Count).Where(item => item.Value0.IsEven()))
                sum += item.Value0;
            return sum;
        }
    }
}

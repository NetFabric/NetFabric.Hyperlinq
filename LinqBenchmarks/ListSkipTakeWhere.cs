using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ListSkipTakeWhere : BenchmarkBase
    {
        List<int> source;

        [Params(1_000)]
        public int Skip { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Skip + Count).ToList();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                var item = source[index];
                if ((item & 0x01) == 0)
                    sum += item;
            }
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
            {
                var item = enumerator.Current;
                if ((item & 0x01) == 0)
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public int LinqFaster()
        //{
        //    var items = JM.LinqFaster.LinqFaster.WhereF(source, item => (item & 0x01) == 0);
        //    var sum = 0;
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq()
        //{
        //    var sum = 0;
        //    foreach (var item in source.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq_IFunction()
        //{
        //    var sum = 0;
        //    var where = new WhereFunction();
        //    foreach (var item in source.ToStructEnumerable().Where(ref where, x => x))
        //        sum += item;
        //    return sum;
        //}

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ListBindings.Skip(source, Skip).Take(Count).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        struct WhereFunction: IFunction<int, bool>
        {
            public bool Eval(int element) 
                => (element & 0x01) == 0;
        }
    }
}

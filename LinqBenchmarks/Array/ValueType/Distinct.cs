using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeDistinct: BenchmarkBase
    {
        FatValueType[] source;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable
                .SelectMany(
                    Enumerable.Range(0, Duplicates), 
                    _ => Enumerable.Range(0, Count / Duplicates)
                        .Select(value => new FatValueType(value)))
                .ToArray();

        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public FatValueType LinqFaster()
        //{
        //    JM.LinqFaster.LinqFaster.DistinctInPlaceF(source);
        //    var sum = default(FatValueType);
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (ref readonly  var item in source.ToRefStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in ArrayExtensions.Distinct(source))
                sum += item;
            return sum;
        }
    }
}

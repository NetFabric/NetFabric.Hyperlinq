using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32Contains: ArrayInt32BenchmarkBase
    {
        int value = int.MaxValue;

        [Benchmark(Baseline = true)]
        public bool ForLoop()
        {
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                if (item == value)
                    return true;
            }
            return true;
        }

        [Benchmark]
        public bool ForeachLoop()
        {
            foreach (var item in source)
            {
                if (item == value)
                    return true;
            }
            return true;
        }

        [Benchmark]
        public bool Linq()
            => System.Linq.Enumerable
                .Contains(source, value);

        [Benchmark]
        public bool LinqFaster()
            => source.ContainsF(value);

        [Benchmark]
        public bool LinqFaster_SIMD()
            => source.ContainsS(value);

        [Benchmark]
        public bool LinqAF()
            => global::LinqAF.ArrayExtensionMethods
                .Contains(source, value);

        [Benchmark]
        public bool StructLinq()
            => source
                .ToStructEnumerable()
                .Contains(value);

        [Benchmark]
        public bool StructLinq_IFunction()
        {
            return source
                .ToStructEnumerable()
                .Contains(value, x => x);
        }

        [Benchmark]
        public bool Hyperlinq()
            => source
                .AsValueEnumerable()
                .Contains(value);

        [Benchmark]
        public bool Hyperlinq_SIMD()
            => source
                .AsValueEnumerable()
                .ContainsVector(value);
    }
}

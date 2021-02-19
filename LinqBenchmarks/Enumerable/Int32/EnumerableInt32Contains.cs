using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32Contains: EnumerableInt32BenchmarkBase
    {
        int value = int.MaxValue;

        [Benchmark(Baseline = true)]
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
            => source.Contains(value);

        [Benchmark]
        public bool LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Contains(source, value);

        [Benchmark]
        public bool StructLinq()
            => source
                .ToStructEnumerable()
                .Contains(value);

        [Benchmark]
        public bool StructLinq_IFunction()
            => source
                .ToStructEnumerable()
                .Contains(value, x => x);

        [Benchmark]
        public bool Hyperlinq()
            => source
                .AsValueEnumerable()
                .Contains(value);
    }
}

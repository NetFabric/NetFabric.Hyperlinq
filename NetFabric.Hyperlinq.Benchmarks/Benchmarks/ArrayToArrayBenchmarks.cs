using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    public class ArrayToArrayBenchmarks
    {
        const int seed = 2982;
        int[]? array;

        [Params(10, 100, 1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup() 
            => array = Utils.GetRandomValues(seed, Count);

        [Benchmark(Baseline = true)]
        public int[] ArrayClone()
            => (int[])array!.Clone();

        [Benchmark]
        public int[] SpanToArray()
            => array.AsSpan().ToArray();
        
        [Benchmark]
        public int[] CollectionCopyTo()
        {
            var result = GC.AllocateUninitializedArray<int>(Count);
            ((System.Collections.ICollection)array!).CopyTo(result, 0);
            return result;
        }
    }
}

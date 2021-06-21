using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    public class ArrayIterationBenchmarks
    {
        const int seed = 2982;
        int[]? array;
        ArraySegment<int> segment;

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = Utils.GetRandomValues(seed, Count);
            segment = new ArraySegment<int>(Utils.GetRandomValues(seed, Count));
        }

        [Benchmark(Baseline = true)]
        public int Foreach()
        {
            var sum = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in array!)
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int For()
        {
            var source = array!;
            var sum = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index <= source.Length - 1; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }
        
        [Benchmark]
        public unsafe int For_Unsafe()
        {
            var len = array!.Length - 1;
            var sum = 0;
            fixed (int* source = array)
            {
                for (var index = 0; index <= len; index++)
                {
                    var item = source[index];
                    sum += item;
                }
            }
            return sum;
        }
        
        [Benchmark]
        public int ForAdamczewski()
        {
            var source = array!;
            var sum1 = 0;
            var sum2 = 0;
            for (var index = 0; index <= source.Length - 2; index += 2)
            {
                long i1 = index + 0;
                long i2 = index + 1;
                var c = source[i1];
                var d = source[i2];

                sum1 += c;
                sum2 += d;
            }
            if ((source.Length & 0x01) != 0)
            {
                sum1 += source[source.Length - 1];
            }
            return sum1 + sum2;
        }
        
        [Benchmark]
        public unsafe int ForAdamczewskiUnsafe()
        {
            fixed (int* source = array)
            {
                var len = array!.Length - 2;
                var sum1 = 0;
                var sum2 = 0;
                for (var index = 0; index <= len; index += 2)
                {
                    long i1 = index + 0;
                    long i2 = index + 1;
                    var c = source[i1];
                    var d = source[i2];
        
                    sum1 += c;
                    sum2 += d;
                }
                if ((array.Length & 0x01) != 0)
                {
                    sum1 += source[array!.Length - 1];
                }
                return sum1 + sum2;
            }
        }
        
        [Benchmark]
        public int Span()
        {
            var source = array.AsSpan();
            var sum = 0;
            foreach (var item in source)
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int ArraySegment_Foreach()
        {
            var sum = 0;
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var item in segment)
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int ArraySegment_For()
        {
            var source = segment;
            var sum = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }
        
        [Benchmark]
        public int ArraySegment_AsSpan()
        {
            var sum = 0;
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var item in segment.AsSpan())
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int ArraySegment_AsArray()
        {
            var source = segment.Array!;
            var end = segment.Offset + segment.Count;
            var sum = 0;
            for (var index = segment.Offset; index < end; index++)
                sum += source[index];
            return sum;
        }

        [Benchmark]
        public int Vector()
        {
            var source = array!;
            var sum = 0;
            var vectors = MemoryMarshal.Cast<int, Vector<int>>(source);
            var vectorSum = Vector<int>.Zero;

            foreach (var vector in vectors)
                vectorSum += vector;

            for (var index = 0; index < Vector<int>.Count; index++)
                sum += vectorSum[index];

            for (var index = source.Length - (source.Length % Vector<int>.Count); index < source.Length; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }    
    }
}

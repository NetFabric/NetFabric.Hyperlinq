﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public class ArrayIterationBenchmarks
    {
        const int seed = 2982;
        int[] array;
        ReadOnlyMemory<int> memory;
        ArraySegment<int> segment;

        [Params(10_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = Utils.GetRandomValues(seed, Count);
            memory = array.AsMemory();
            segment = new ArraySegment<int>(array);
        }

        [Benchmark(Baseline = true)]
        public int Foreach()
        {
            var sum = 0;
            foreach (var item in array)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int For()
        {
            var source = array;
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = array[index];
                sum += item;
            }
            return sum;
        }

        //[Benchmark]
        //public unsafe int For_Unsafe()
        //{
        //    var end = array.Length;
        //    var sum = 0;
        //    fixed (int* source = array)
        //    {
        //        for (var index = 0; index < end; index++)
        //        {
        //            var item = array[index];
        //            sum += item;
        //        }
        //    }
        //    return sum;
        //}

        //[Benchmark]
        //public int ForAdamczewski()
        //{
        //    var source = array;
        //    var len = array.Length;
        //    var sum1 = 0;
        //    var sum2 = 0;
        //    for (var index = 0; index < len; index += 2)
        //    {
        //        long i1 = index + 0;
        //        long i2 = index + 1;
        //        var c = source[i1];
        //        var d = source[i2];

        //        sum1 += c;
        //        sum2 += d;
        //    }
        //    return sum1 + sum2;
        //}

        //[Benchmark]
        //public unsafe int ForAdamczewskiUnsafe()
        //{
        //    fixed (int* source = array)
        //    {
        //        var len = array.Length;
        //        var sum1 = 0;
        //        var sum2 = 0;
        //        for (var index = 0; index < len; index += 2)
        //        {
        //            long i1 = index + 0;
        //            long i2 = index + 1;
        //            var c = source[i1];
        //            var d = source[i2];

        //            sum1 += c;
        //            sum2 += d;
        //        }
        //        return sum1 + sum2;
        //    }
        //}

        //[Benchmark]
        //public int Span()
        //{
        //    var source = array.AsSpan();
        //    var sum = 0;
        //    for (var index = 0; index < source.Length; index++)
        //    {
        //        var item = source[index];
        //        sum += item;
        //    }
        //    return sum;
        //}

        //[Benchmark]
        //public int Memory()
        //{
        //    var source = memory.Span;
        //    var sum = 0;
        //    for (var index = 0; index < source.Length; index++)
        //    {
        //        var item = source[index];
        //        sum += item;
        //    }
        //    return sum;
        //}

        [Benchmark]
        public int ArraySegment()
        {
            var source = segment.Array;
            var start = segment.Offset;
            var end = start + segment.Count;
            var sum = 0;
            for (var index = start; index < end; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }
    }
}

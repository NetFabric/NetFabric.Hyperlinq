using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    public class CachingBenchmarks
    {
        ConcurrentDictionary<Type, int> concurrentDictionary = 
            new ConcurrentDictionary<Type, int>();

        LockingConcurrentDictionary<Type, int> lockingConcurrentDictionary = 
            new LockingConcurrentDictionary<Type, int>(type => CreateValue(type));

        static class ValueCache<TValue>
        {
            public static readonly int value = CreateValue(typeof(TValue));
        }

        static int CreateValue(Type type) => 1;    

        [Benchmark(Baseline = true)]
        public int ConcurrentDictionary() => 
            concurrentDictionary.GetOrAdd(typeof(int), type => CreateValue(type));

        [Benchmark]
        public int LockingConcurrentDictionary() => 
            lockingConcurrentDictionary.GetOrAdd(typeof(int));

        [Benchmark]
        public int StaticCache() => 
            ValueCache<int>.value;
    }

}
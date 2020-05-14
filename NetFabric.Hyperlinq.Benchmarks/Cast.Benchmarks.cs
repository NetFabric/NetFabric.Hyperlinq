using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class CastBenchmarks
    {
        IEnumerable<int> enumerable;
        IReadOnlyList<int> list;

        [GlobalSetup]
        public void GlobalSetup()
        {
            enumerable = TestEnumerable.ReferenceType(10);
#pragma warning disable HLQ001 // Assigment to interface causes boxing of enumerator
            list = ValueEnumerable.Range(0, 10).ToList();
#pragma warning restore HLQ001 // Assigment to interface causes boxing of enumerator
        }

        [Benchmark(Baseline = true)]
        public bool EnumerableIsEnumerable() => 
            enumerable is IEnumerable<int>;

        [Benchmark]
        public bool EnumerableIsReadOnlyList() => 
            enumerable is IReadOnlyList<int>;

        static readonly Type type = typeof(IReadOnlyList<>).MakeGenericType(typeof(int));

        [Benchmark]
        public bool EnumerableIsReadOnlyList2() => 
            type.IsAssignableFrom(enumerable.GetType());

        [Benchmark]
        public bool EnumerableIsList() => 
            enumerable is IList<int>;

        [Benchmark]
        public bool ListIsEnumerable() => 
            list is IEnumerable<int>;

        [Benchmark]
        public bool ListIsReadOnlyList() => 
            list is IReadOnlyList<int>;

        [Benchmark]
        public bool ListIsList() => 
            list is IList<int>;
    }
}

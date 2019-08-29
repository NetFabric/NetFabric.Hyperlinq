using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    public class IndexerBenchmarks
    {
        TestEnumerable.Enumerable enumerableValue;
        IEnumerable<int> enumerableReference;
        TestList.Enumerable listValue;
        IReadOnlyList<int> listReference;

        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            enumerableValue = TestEnumerable.ValueType(Count);
            enumerableReference = TestEnumerable.ReferenceType(Count);
            listValue = TestList.ValueType(Count);
            listReference = TestList.ReferenceType(Count);
        }

        [Benchmark(Baseline = true)]
        public bool Enumerator_Reference() => 
            AllEnumerable(enumerableReference, _ => true);

        [Benchmark]
        public bool Enumerator_Value() =>
            AllEnumerable(enumerableValue, _ => true);

        [Benchmark]
        public bool Indexer_Reference() => 
            AllIndexer(listReference, _ => true);

        [Benchmark]
        public bool Indexer_Value() =>
            AllIndexer(listValue, _ => true);

        [Benchmark]
        public bool Hyperlinq_Reference() =>
            listReference.AsValueEnumerable().All(_ => true);

        [Benchmark]
        public bool Hyperlinq_Value() =>
            ReadOnlyList.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator()).All(_ => true);

        static bool AllEnumerable(TestEnumerable.Enumerable source, Func<int, bool> predicate)
        {
            foreach(var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        static bool AllEnumerable(IEnumerable<int> source, Func<int, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        static bool AllIndexer(TestList.Enumerable source, Func<int, bool> predicate)
        {
            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        static bool AllIndexer(IReadOnlyList<int> source, Func<int, bool> predicate)
        {
            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }
    }
}

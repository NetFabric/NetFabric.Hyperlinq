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
            AllEnumerable(enumerableReference, item => (item & 0x01) == 0);

        [Benchmark]
        public bool Enumerator_Value() =>
            AllEnumerable(enumerableValue, item => (item & 0x01) == 0);

        [Benchmark]
        public bool Indexer_Reference() => 
            AllIndexer(listReference, item => (item & 0x01) == 0);

        [Benchmark]
        public bool Indexer_Value() =>
            AllIndexer(listValue, item => (item & 0x01) == 0);

        [Benchmark]
        public bool Hyperlinq_Reference() =>
            listReference.AsValueEnumerable().All(item => (item & 0x01) == 0);

        [Benchmark]
        public bool Hyperlinq_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue).All(item => (item & 0x01) == 0);

        static bool AllEnumerable(TestEnumerable.Enumerable source, Predicate<int> predicate)
        {
            foreach(var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        static bool AllEnumerable(IEnumerable<int> source, Predicate<int> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        static bool AllIndexer(TestList.Enumerable source, Predicate<int> predicate)
        {
            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        static bool AllIndexer(IReadOnlyList<int> source, Predicate<int> predicate)
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

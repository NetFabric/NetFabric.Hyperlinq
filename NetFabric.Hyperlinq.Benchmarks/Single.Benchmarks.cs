#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SingleBenchmarks
    {
        int[] array;
        Memory<int> memory;

        IEnumerable<int> enumerableReference;
        TestEnumerable.Enumerable enumerableValue;

        IReadOnlyCollection<int> collectionReference;
        TestCollection.Enumerable collectionValue;

        IReadOnlyList<int> listReference;
        TestList.Enumerable listValue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = new int[] { 0 };
            memory = array.AsMemory();

            enumerableReference = TestEnumerable.ReferenceType(1);
            enumerableValue = TestEnumerable.ValueType(1);

            collectionReference = TestCollection.ReferenceType(1);
            collectionValue = TestCollection.ValueType(1);

            listReference = TestList.ReferenceType(1);
            listValue = TestList.ValueType(1);
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.Single(array);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.Single(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value() =>
            System.Linq.Enumerable.Single(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value() =>
            System.Linq.Enumerable.Single(listValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.Single(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference() =>
            System.Linq.Enumerable.Single(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference() =>
            System.Linq.Enumerable.Single(listReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Array() =>
            array.Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Span() =>
            array.AsSpan().Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Memory() =>
            memory.Single();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Single();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Single();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue)
            .Single();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Single();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Single();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Single();
    }
}

#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

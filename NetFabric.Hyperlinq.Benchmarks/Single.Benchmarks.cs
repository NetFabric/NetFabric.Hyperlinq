using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SingleBenchmarks
    {
        LinkedList<int> linkedList;
        int[] array;
        List<int> list;
        IEnumerable<int> linqRange;
        ValueEnumerable.RangeEnumerable hyperlinqRange;
        IEnumerable<int> enumerableReference;
        TestEnumerable.Enumerable enumerableValue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, 1);
            hyperlinqRange = ValueEnumerable.Range(0, 1);
            array = hyperlinqRange.ToArray();
            list = hyperlinqRange.ToList();
            linkedList = new LinkedList<int>(hyperlinqRange);
            enumerableReference = TestEnumerable.ReferenceType(1);
            enumerableValue = TestEnumerable.ValueType(1);
        }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() => 
            System.Linq.Enumerable.Single(linqRange);

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public int Linq_LinkedList() => 
            System.Linq.Enumerable.Single(linkedList);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() => 
            System.Linq.Enumerable.Single(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() => 
            System.Linq.Enumerable.Single(list);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Single(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Single(enumerableValue);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() =>
            hyperlinqRange.Single();

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public int Hyperlinq_LinkedList() =>
            linkedList.Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() => 
            array.Single();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() => 
            list.Single();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() => 
            enumerableReference
            .AsValueEnumerable()
            .Single();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() => 
            enumerableValue
            .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
            .Single();
    }
}

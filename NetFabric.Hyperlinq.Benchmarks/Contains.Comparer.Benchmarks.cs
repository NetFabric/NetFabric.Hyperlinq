using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ContainsComparerBenchmarks : BenchmarksBase, IEqualityComparer<int>
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public bool Linq_Range() =>
            System.Linq.Enumerable.Contains(linqRange, Count - 1, this);

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public bool Linq_Queue() => 
            System.Linq.Enumerable.Contains(queue, Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() =>
            System.Linq.Enumerable.Contains(array, Count - 1, this);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public bool Linq_List() => 
            System.Linq.Enumerable.Contains(list, Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Contains(enumerableReference, Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Contains(enumerableValue, Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.ContainsF(Count - 1, this);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool LinqFaster_List() =>
            list.ContainsF(Count - 1, this);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool System_List() =>
            list.Contains(Count - 1, this);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public bool Hyperlinq_Range() =>
            hyperlinqRange.Contains(Count - 1, this);

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public bool Hyperlinq_Queue() => 
            queue.Contains(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.Contains(Count - 1, this);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool Hyperlinq_List() =>
            list.Contains(Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() => 
            enumerableReference.Contains(Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() => 
            enumerableValue.Contains<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(Count - 1, this);

        public bool Equals(int x, int y) 
            => x.Equals(y);

        public int GetHashCode(int obj)
            => obj.GetHashCode();
    }
}

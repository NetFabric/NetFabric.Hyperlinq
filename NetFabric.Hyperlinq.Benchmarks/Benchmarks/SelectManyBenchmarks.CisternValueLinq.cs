#if !(NETCOREAPP2_1 || NET48)

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public partial class SelectManyBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int CisternValueLinq_Array() =>
            array
            .SelectMany(item => Enumerable.Return(item))
            .Sum();


        [BenchmarkCategory("Array")]
        [Benchmark]
        public int CisternValueLinq_Memory() =>
            memory
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int CisternValueLinq_Enumerable_Value() =>
            enumerableValue
            .OfEnumeratorConstraint<int, TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator>(x => x.GetEnumerator())
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int CisternValueLinq_Collection_Value() =>
            collectionValue
            .OfEnumeratorConstraint<int, TestCollection.Enumerable, TestCollection.Enumerable.Enumerator>(x => x.GetEnumerator(), collectionValue.Count)
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int CisternValueLinq_List_Value() =>
            listValue
            .OfReadOnlyListConstraint<int, TestList.Enumerable>()
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int CisternValueLinq_Enumerable_Reference() =>
            enumerableReference
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int CisternValueLinq_Collection_Reference() =>
            collectionReference
            .SelectMany(item => Enumerable.Return(item))
            .Sum();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int CisternValueLinq_List_Reference() =>
            listReference
            .SelectMany(item => Enumerable.Return(item))
            .Sum();
    }
}

#endif
#if !(NETCOREAPP2_1 || NET48)

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public partial class AllBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool CisternValueLinq_Array() =>
            array
            .OfArray() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .All(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool CisternValueLinq_Span() =>
            Enumerable
            .FromSpan<int[], int>(array, array => array.AsSpan())
            .All(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool CisternValueLinq_Memory() =>
            memory
            .OfMemory() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .All(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool CisternValueLinq_Enumerable_Value() =>
            enumerableValue
            .OfEnumeratorConstraint<int, TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator>(x => x.GetEnumerator())
            .All(_ => true);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool CisternValueLinq_Collection_Value() =>
            collectionValue
            .OfEnumeratorConstraint<int, TestCollection.Enumerable, TestCollection.Enumerable.Enumerator>(x => x.GetEnumerator(), collectionValue.Count)
            .All(_ => true);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool CisternValueLinq_List_Value() =>
            listValue
            .OfReadOnlyListConstraint<int, TestList.Enumerable>()
            .All(_ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool CisternValueLinq_Enumerable_Reference() =>
            enumerableReference
            .OfEnumerable() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .All(_ => true);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool CisternValueLinq_Collection_Reference() =>
            collectionReference
            .OfEnumerable() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .All(_ => true);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool CisternValueLinq_List_Reference() =>
            listReference
            .OfEnumerable() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .All(_ => true);
    }
}

#endif
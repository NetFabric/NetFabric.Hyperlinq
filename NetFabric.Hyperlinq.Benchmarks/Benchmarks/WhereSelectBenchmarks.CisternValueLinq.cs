#if !(NETCOREAPP2_1 || NET48)

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public partial class WhereSelectBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int CisternValueLinq_Array() =>
            array
            .OfArray() // *shouldn't* need this!!! only because we are in the NetFabric.Hyperlinq namespace; so c# chooses incorrect overload
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int CisternValueLinq_Enumerable_Value() =>
            enumerableValue
            .OfEnumeratorConstraint<int, TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator>(x => x.GetEnumerator())
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int CisternValueLinq_Collection_Value() =>
            collectionValue
            .OfEnumeratorConstraint<int, TestCollection.Enumerable, TestCollection.Enumerable.Enumerator>(x => x.GetEnumerator(), collectionValue.Count)
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int CisternValueLinq_List_Value() =>
            listValue
            .OfReadOnlyListConstraint<int, TestList.Enumerable>()
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int CisternValueLinq_Enumerable_Reference() =>
            enumerableReference
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int CisternValueLinq_Collection_Reference() =>
            collectionReference
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int CisternValueLinq_List_Reference() =>
            listReference
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Sum();

        // ------

        struct IsEven : IFunc<int, bool> { public bool Invoke(int item) => (item & 0x01) == 0; }
        struct Identity : IFunc<int, int> { public int Invoke(int item) => item; }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_Array() =>
            array
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_Enumerable_Value() =>
            enumerableValue
            .OfEnumeratorConstraint<int, TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator>(x => x.GetEnumerator())
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_Collection_Value() =>
            collectionValue
            .OfEnumeratorConstraint<int, TestCollection.Enumerable, TestCollection.Enumerable.Enumerator>(x => x.GetEnumerator(), collectionValue.Count)
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_List_Value() =>
            listValue
            .OfReadOnlyListConstraint<int, TestList.Enumerable>()
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_Enumerable_Reference() =>
            enumerableReference
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_Collection_Reference() =>
            collectionReference
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int CisternValueLinq_ValueLambda_List_Reference() =>
            listReference
            .Where(new IsEven())
            .Select(new Identity(), default(int))
            .Sum();
    }
}
#endif
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    //[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp21)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public abstract class BenchmarksBase
    {
        protected int[] array;
        protected ReadOnlyMemory<int> memory;
        protected List<int> list;
        protected LinkedList<int> linkedList;

        protected IEnumerable<int> linqRange;
        protected ValueEnumerable.RangeEnumerable hyperlinqRange;

        protected IEnumerable<int> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;

        protected IReadOnlyCollection<int> collectionReference;
        protected TestCollection.Enumerable collectionValue;

        protected IReadOnlyList<int> listReference;
        protected TestList.Enumerable listValue;

        protected IAsyncEnumerable<int> asyncEnumerableReference;
        protected TestAsyncEnumerable.AsyncEnumerable asyncEnumerableValue;

        [Params(100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, Count);
            hyperlinqRange = ValueEnumerable.Range(0, Count);

            array = hyperlinqRange.ToArray();
            memory = array.AsMemory();
            list = new List<int>(hyperlinqRange);
            linkedList = new LinkedList<int>(hyperlinqRange);

            enumerableReference = TestEnumerable.ReferenceType(Count);
            enumerableValue = TestEnumerable.ValueType(Count);

            collectionReference = TestCollection.ReferenceType(Count);
            collectionValue = TestCollection.ValueType(Count);

            listReference = TestList.ReferenceType(Count);
            listValue = TestList.ValueType(Count);

            asyncEnumerableReference = TestAsyncEnumerable.ReferenceType(Count);
            asyncEnumerableValue = TestAsyncEnumerable.ValueType(Count);
        }
    }
}

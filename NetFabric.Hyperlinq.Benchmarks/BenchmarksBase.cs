using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace NetFabric.Hyperlinq.Benchmarks
{
    //[SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp21)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public abstract class BenchmarksBase
    {
        protected const int seed = 42;

        protected int[] array;
        protected ReadOnlyMemory<int> memory;

        protected IEnumerable<int> linqRange;
        protected ValueEnumerable.RangeEnumerable hyperlinqRange;

        protected IEnumerable<int> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;

        protected IReadOnlyCollection<int> collectionReference;
        protected TestCollection.Enumerable collectionValue;

        protected IReadOnlyList<int> listReference;
        protected TestList.Enumerable listValue;

        protected IAsyncEnumerable<int> asyncEnumerableReference;
        protected TestAsyncEnumerable.Enumerable asyncEnumerableValue;

        [GlobalSetup]
        public abstract void GlobalSetup();

        protected void Initialize(int[] array)
        {
            this.array = array;
            memory = array.AsMemory();

            enumerableReference = TestEnumerable.ReferenceType(array);
            enumerableValue = TestEnumerable.ValueType(array);

            collectionReference = TestCollection.ReferenceType(array);
            collectionValue = TestCollection.ValueType(array);

            listReference = TestList.ReferenceType(array);
            listValue = TestList.ValueType(array);

            asyncEnumerableReference = TestAsyncEnumerable.ReferenceType(array);
            asyncEnumerableValue = TestAsyncEnumerable.ValueType(array);
        }
    }
}

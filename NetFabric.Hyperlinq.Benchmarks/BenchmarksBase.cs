using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class BenchmarksBase
    {
        protected const int seed = 42;
        
        protected int[] array;
        protected ReadOnlyMemory<int> memory;

        protected IEnumerable<int> enumerableReference;
        protected Wrap.EnumerableWrapper<int> enumerableValue;

        protected IReadOnlyCollection<int> collectionReference;
        protected Wrap.CollectionWrapper<int> collectionValue;

        protected IReadOnlyList<int> listReference;
        protected Wrap.ListWrapper<int> listValue;

        protected IAsyncEnumerable<int> asyncEnumerableReference;
        protected Wrap.AsyncEnumerableWrapper<int> asyncEnumerableValue;

        [GlobalSetup]
        public abstract void GlobalSetup();

        protected void Initialize(int[] array)
        {
            this.array = array;
            memory = array.AsMemory();

            enumerableReference = enumerableValue = Wrap.AsEnumerable(array);
            collectionReference = collectionValue = Wrap.AsCollection(array);
            listReference = listValue = Wrap.AsList(array);
            asyncEnumerableReference = asyncEnumerableValue = Wrap.AsAsyncEnumerable(array);
        }
    }
}

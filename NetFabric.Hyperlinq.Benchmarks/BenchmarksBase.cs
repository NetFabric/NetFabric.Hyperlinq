using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class BenchmarksBase
    {
        protected int[] array;
        protected List<int> list;
        protected Queue<int> queue;

        protected IEnumerable<int> linqRange;
        protected ValueEnumerable.RangeEnumerable hyperlinqRange;

        protected IEnumerable<int> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;

        protected IReadOnlyCollection<int> collectionReference;
        protected TestReadOnlyCollection.EnumerableValueType collectionValue;

        protected IReadOnlyList<int> listReference;
        protected TestReadOnlyList.EnumerableValueType listValue;

        [Params(0, 100, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Setup(Count);
        }

        void Setup(int count)
        {
            linqRange = System.Linq.Enumerable.Range(0, count);
            hyperlinqRange = ValueEnumerable.Range(0, count);

            queue = new Queue<int>(linqRange);
            array = hyperlinqRange.ToArray();
            list = new List<int>(linqRange);

            enumerableReference = TestEnumerable.ReferenceType(count);
            enumerableValue = TestEnumerable.ValueType(count);

            collectionReference = TestReadOnlyCollection.ReferenceType(count);
            collectionValue = TestReadOnlyCollection.ValueType(count);

            listReference = TestReadOnlyList.ReferenceType(count);
            listValue = TestReadOnlyList.ValueType(count);
        }
    }
}

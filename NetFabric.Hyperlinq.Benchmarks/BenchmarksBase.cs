using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class BenchmarksBase
    {
        protected int[] array;
        protected List<int> list;
        protected LinkedList<int> linkedList;

        protected IEnumerable<int> linqRange;
        protected ValueEnumerable.RangeEnumerable hyperlinqRange;

        protected IEnumerable<int> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;

        protected TestCollection.EnumerableReferenceType collectionReference;
        protected TestCollection.EnumerableValueType collectionValue;

        protected TestList.EnumerableReferenceType listReference;
        protected TestList.EnumerableValueType listValue;

        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, Count);
            hyperlinqRange = ValueEnumerable.Range(0, Count);

            array = hyperlinqRange.ToArray();
            list = new List<int>(hyperlinqRange);
            linkedList = new LinkedList<int>(hyperlinqRange);

            enumerableReference = TestEnumerable.ReferenceType(Count);
            enumerableValue = TestEnumerable.ValueType(Count);

            collectionReference = TestCollection.ReferenceType(Count);
            collectionValue = TestCollection.ValueType(Count);

            listReference = TestList.ReferenceType(Count);
            listValue = TestList.ValueType(Count);
        }
    }
}

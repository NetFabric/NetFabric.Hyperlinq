using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class BenchmarksBase
    {
        protected int[] array;
        protected List<int> list;
        protected IEnumerable<int> linqRange;
        protected Enumerable.RangeEnumerable hyperlinqRange;
        protected IEnumerable<int> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;
        protected IEnumerable<int> arrayAsEnumerable;
        protected IReadOnlyCollection<int> arrayAsReadOnlyCollection;
        protected IReadOnlyList<int> arrayAsReadOnlyList;
        protected IEnumerable<int> listAsEnumerable;
        protected IReadOnlyCollection<int> listAsReadOnlyCollection;
        protected IReadOnlyList<int> listAsReadOnlyList;

        [Params(0, 100, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Setup(Count);
        }

        public void Setup(int count)
        {
            linqRange = System.Linq.Enumerable.Range(0, count);
            hyperlinqRange = Enumerable.Range(0, count);
            array = hyperlinqRange.ToArray();
            list = hyperlinqRange.ToList();
            enumerableReference = TestEnumerable.ReferenceType(count);
            enumerableValue = TestEnumerable.ValueType(count);
            arrayAsEnumerable = array;
            arrayAsReadOnlyCollection = array;
            arrayAsReadOnlyList = array;
            listAsEnumerable = list;
            listAsReadOnlyCollection = list;
            listAsReadOnlyList = list;
        }
    }
}

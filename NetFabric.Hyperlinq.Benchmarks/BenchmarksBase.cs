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
        protected Enumerable.RangeReadOnlyList hyperlinqRange;
        protected IEnumerable<int> enumerableReference;
        protected MyEnumerable.Enumerable enumerableValue;

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
            enumerableReference = MyEnumerable.ReferenceType(count);
            enumerableValue = MyEnumerable.ValueType(count);
        }
    }
}

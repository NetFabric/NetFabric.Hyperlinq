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
        protected Enumerable.RangeEnumerable hyperlinqRange;
        protected IEnumerable<long> enumerableReference;
        protected TestEnumerable.Enumerable enumerableValue;

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
            hyperlinqRange = Enumerable.Range(0, count);
            queue = new Queue<int>(linqRange);
            array = linqRange.ToArray();
            list = new List<int>(linqRange);
            enumerableReference = TestEnumerable.ReferenceType(count);
            enumerableValue = TestEnumerable.ValueType(count);
        }
    }
}

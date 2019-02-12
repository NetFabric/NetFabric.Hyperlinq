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
        protected IEnumerable<int> enumerable;

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
            enumerable = MyEnumerable();

            IEnumerable<int> MyEnumerable()
            {
                for (var value = 0; value < count; value++)
                    yield return value;
            }
        }
    }
}

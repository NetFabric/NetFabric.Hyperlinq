#if NET5_0_OR_GREATER

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using StructLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.Range
{
    public partial class RangeToList : RangeBenchmarkBase
    {
        [Benchmark]
        public List<int> ValueLinq_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .ToListUsePool(viaPull: true);
    }
}
#endif
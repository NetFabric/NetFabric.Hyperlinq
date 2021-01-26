#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using StructLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.Range
{
    public partial class RangeSelectToList: RangeBenchmarkBase
    {
        [Benchmark]
        public List<int> ValueLinq_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToListUsePool(viaPull: true);


        struct MultipleByTwo : IFunc<int, int> { public int Invoke(int t) => t * 2; }

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: true);
    }
}
#endif
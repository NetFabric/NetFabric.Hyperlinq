#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using StructLinq;
using System.Buffers;

namespace LinqBenchmarks.Range
{
    public partial class RangeSelectToArray: RangeBenchmarkBase
    {
        [Benchmark]
        public int[] ValueLinq_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: true);


        struct MultipleByTwo : IFunc<int, int> { public int Invoke(int t) => t * 2; }

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUsePool(viaPull: true);
    }
}
#endif
#if NET5_0_OR_GREATER

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
            .Select(item => item * 3)
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: true);


        [Benchmark]
        public int[] ValueLinq_ValueLambda_Standard() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new TripleOfInt32(), default(int))
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Stack() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Push() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Pull() =>
            Cistern.ValueLinq.Enumerable
            .Range(Start, Count)
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: true);
    }
}
#endif
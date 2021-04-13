#if NET5_0_OR_GREATER

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using StructLinq;
using System.Buffers;

namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32WhereSelectToArray: ArrayInt32BenchmarkBase
    {
        [Benchmark]
        public int[] ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: true);
        
        [Benchmark]
        public int[] ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: true);
    }
}

#endif
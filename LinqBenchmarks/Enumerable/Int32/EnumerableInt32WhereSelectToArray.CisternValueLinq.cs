#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32WhereSelectToArray : EnumerableInt32BenchmarkBase
    {
        [Benchmark]
        public int[] ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: true);


        struct IsEven : IFunc<int, bool> { public bool Invoke(int t) => t.IsEven(); }
        struct MultipleByTwo : IFunc<int, int> { public int Invoke(int t) => t * 2; }

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToArrayUsePool(viaPull: true);
    }
}

#endif
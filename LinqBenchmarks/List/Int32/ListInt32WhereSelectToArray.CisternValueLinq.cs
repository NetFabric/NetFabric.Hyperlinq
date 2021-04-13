#if NET5_0_OR_GREATER

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;


namespace LinqBenchmarks.List.Int32
{
    public partial class ListInt32WhereSelectToArray: Int32ListBenchmarkBase
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






        [Benchmark]
        public int[] ValueLinq_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArrayUsePool(viaPull: true);


        [Benchmark]
        public int[] ValueLinq_ValueLambda_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArray();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUseStack();

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public int[] ValueLinq_ValueLambda_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToArrayUsePool(viaPull: true);
    }
}

#endif
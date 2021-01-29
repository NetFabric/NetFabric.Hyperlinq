#if !NETFRAMEWORK


using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;

namespace LinqBenchmarks.Array.ValueType
{
    public partial class ArrayValueTypeWhereSelectToArray: ValueTypeArrayBenchmarkBase
    {
        [Benchmark]
        public FatValueType[] ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: true);

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_Standard() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_Stack() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_SharedPool_Push() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_SharedPool_Pull() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUsePool(viaPull: true);


        struct IsEven : IFunc<FatValueType, bool> { public bool Invoke(FatValueType t) => t.IsEven(); }
        struct MultipleByTwo : IFunc<FatValueType, FatValueType> { public FatValueType Invoke(FatValueType t) => t * 2; }

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: false);
        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: true);
    }
}

#endif
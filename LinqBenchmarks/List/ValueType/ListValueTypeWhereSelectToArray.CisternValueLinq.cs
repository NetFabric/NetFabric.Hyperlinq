#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;

namespace LinqBenchmarks.List.ValueType
{
    public partial class ListValueTypeWhereSelectToArray: ValueTypeListBenchmarkBase
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

        struct InIsEven : IInFunc<FatValueType, bool> { public bool Invoke(in FatValueType t) => t.IsEven(); }
        struct InMultipleByTwo : IInFunc<FatValueType, FatValueType> { public FatValueType Invoke(in FatValueType t) => t * 2; }

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_Standard() =>
            source
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_Stack() =>
            source
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_SharedPool_Push() =>
            source
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_SharedPool_Pull() =>
            source
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: true);






        [Benchmark]
        public FatValueType[] ValueLinq_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToArrayUsePool(viaPull: true);

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_Ref_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToArrayUsePool(viaPull: true);

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: false);
        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: true);

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArray();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUseStack();

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: false);

        [Benchmark]
        public FatValueType[] ValueLinq_ValueLambda_Ref_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new InIsEven())
            .Select(new InMultipleByTwo(), default(FatValueType))
            .ToArrayUsePool(viaPull: true);
    }
}

#endif
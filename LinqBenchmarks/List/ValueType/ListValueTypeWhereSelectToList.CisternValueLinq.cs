#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.List.ValueType
{
    public partial class ListValueTypeWhereSelectToList: ValueTypeListBenchmarkBase
    {
        [Benchmark]
        public List<FatValueType> ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: true);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Standard() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Stack() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Push() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Pull() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUsePool(viaPull: true);


        struct IsEven : IFunc<FatValueType, bool> { public bool Invoke(FatValueType t) => t.IsEven(); }
        struct MultipleByTwo : IFunc<FatValueType, FatValueType> { public FatValueType Invoke(FatValueType t) => t * 2; }

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUsePool(viaPull: false);
        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUsePool(viaPull: true);


        [Benchmark]
        public List<FatValueType> ValueLinq_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: true);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 2)
            .ToListUsePool(viaPull: true);

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUsePool(viaPull: false);
        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(FatValueType))
            .ToListUsePool(viaPull: true);
    }
}

#endif
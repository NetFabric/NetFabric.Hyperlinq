#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.Array.ValueType
{
    public partial class ArrayValueTypeWhereSelectToList
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
            .ToListUsePool(viaPull:false);

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull:true);

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
    }
}

#endif
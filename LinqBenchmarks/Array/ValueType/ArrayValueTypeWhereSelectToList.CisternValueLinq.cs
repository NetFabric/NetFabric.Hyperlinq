#if NET5_0_OR_GREATER

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
            .Select(item => item * 3)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUsePool(viaPull:false);

        [Benchmark]
        public List<FatValueType> ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUsePool(viaPull:true);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Standard() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_Stack() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Push() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<FatValueType> ValueLinq_Ref_SharedPool_Pull() =>
            source
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToListUsePool(viaPull: true);


        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new FatValueTypeIsEven())
            .Select(new TripleOfFatValueType(), default(FatValueType))
            .ToList();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new FatValueTypeIsEven())
            .Select(new TripleOfFatValueType(), default(FatValueType))
            .ToListUseStack();

        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new FatValueTypeIsEven())
            .Select(new TripleOfFatValueType(), default(FatValueType))
            .ToListUsePool(viaPull: false);
        [Benchmark]
        public List<FatValueType> ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new FatValueTypeIsEven())
            .Select(new TripleOfFatValueType(), default(FatValueType))
            .ToListUsePool(viaPull: true);
    }
}

#endif
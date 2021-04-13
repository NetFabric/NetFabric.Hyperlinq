#if NET5_0_OR_GREATER

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32WhereSelectToList
    {
        [Benchmark]
        public List<int> ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToListUsePool(viaPull: true);
        
        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new Int32IsEven())
            .Select(new TripleOfInt32(), default(int))
            .ToListUsePool(viaPull: true);
    }
}

#endif
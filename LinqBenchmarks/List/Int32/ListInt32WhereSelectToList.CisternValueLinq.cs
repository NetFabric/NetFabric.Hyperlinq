#if !NETFRAMEWORK

using BenchmarkDotNet.Attributes;
using Cistern.ValueLinq;
using System.Collections.Generic;

namespace LinqBenchmarks.List.Int32
{
    public partial class ListInt32WhereSelectToList: Int32ListBenchmarkBase
    {
        [Benchmark]
        public List<int> ValueLinq_Standard() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_Stack() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Push() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Pull() =>
            source
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: true);


        struct IsEven : IFunc<int, bool> { public bool Invoke(int t) => t.IsEven(); }
        struct MultipleByTwo : IFunc<int, int> { public int Invoke(int t) => t * 2; }

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Standard() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Stack() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Push() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Pull() =>
            source
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: true);



        [Benchmark]
        public List<int> ValueLinq_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(item => item.IsEven())
            .Select(item => item * 2)
            .ToListUsePool(viaPull: true);

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Standard_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToList();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_Stack_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUseStack();

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Push_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: false);

        [Benchmark]
        public List<int> ValueLinq_ValueLambda_SharedPool_Pull_ByIndex() =>
            source
            .OfListByIndex()
            .Where(new IsEven())
            .Select(new MultipleByTwo(), default(int))
            .ToListUsePool(viaPull: true);
    }
}

#endif
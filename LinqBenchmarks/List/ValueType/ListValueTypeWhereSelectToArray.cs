using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.ValueType;

public partial class ListValueTypeWhereSelectToArray: ValueTypeListBenchmarkBase
{
    Func<FatValueType[]> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray()
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public FatValueType[] ForLoop()
    {
        var list = new List<FatValueType>();
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list.ToArray();
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public FatValueType[] ForeachLoop()
    {
        var list = new List<FatValueType>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list.ToArray();
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public FatValueType[] Linq()
        => System.Linq.Enumerable
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] LinqFaster()
        => source
            .WhereSelectF(item => item.IsEven(), item => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] LinqFasterer()
        => EnumerableF.ToArrayF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );

    [Benchmark]
    public FatValueType[] LinqAF()
        => global::LinqAF.ListExtensionMethods
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] LinqOptimizer()
        => linqOptimizerQuery.Invoke();

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public FatValueType[] SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();
#endif
    
    [Benchmark]
    public FatValueType[] Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] StructLinq()
        => source
            .ToRefStructEnumerable()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] StructLinq_ValueDelegate()
    {
        var predicate = new FatValueTypeIsEven();
        var selector = new TripleOfFatValueType();
        return source.ToRefStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToArray(x=> x);
    }

    [Benchmark]
    public FatValueType[] Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public FatValueType[] Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<FatValueTypeIsEven>()
            .Select<FatValueType, TripleOfFatValueType>()
            .ToArray();

    [Benchmark]
    public FatValueType[] Faslinq() 
        => ListExtensions.WhereSelect(
                source, 
                item => item.IsEven(), 
                item => item * 3)
            .ToArray();
}
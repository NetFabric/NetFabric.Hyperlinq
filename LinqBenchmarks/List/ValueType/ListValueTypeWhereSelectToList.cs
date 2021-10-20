using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

namespace LinqBenchmarks.List.ValueType;

public partial class ListValueTypeWhereSelectToList: ValueTypeListBenchmarkBase
{
    Func<List<FatValueType>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList()
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public List<FatValueType> ForLoop()
    {
        var list = new List<FatValueType>();
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public List<FatValueType> ForeachLoop()
    {
        var list = new List<FatValueType>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public List<FatValueType> Linq()
        => System.Linq.Enumerable
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> LinqFaster()
        => new(source.WhereSelectF(item => item.IsEven(), item => item * 3));

    [Benchmark]
    public List<FatValueType> LinqFasterer()
        => EnumerableF.ToListF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );

    [Benchmark]
    public List<FatValueType> LinqAF()
        => global::LinqAF.ListExtensionMethods
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> LinqOptimizer()
        => linqOptimizerQuery.Invoke();

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public List<FatValueType> SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();
#endif

    [Benchmark]
    public List<FatValueType> Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> StructLinq()
        => source
            .ToRefStructEnumerable()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> StructLinq_ValueDelegate()
    {
        var predicate = new FatValueTypeIsEven();
        var selector = new TripleOfFatValueType();
        return source.ToRefStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToList(x => x);
    }

    [Benchmark]
    public List<FatValueType> Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<FatValueTypeIsEven>()
            .Select<FatValueType, TripleOfFatValueType>()
            .ToList();

    [Benchmark]
    public List<FatValueType> Faslinq() 
        => ListExtensions.WhereSelect(
            source, 
            item => item.IsEven(), 
            item => item * 3);
}
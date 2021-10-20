using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.Int32;

public partial class ListInt32WhereSelectToList : Int32ListBenchmarkBase
{
    Func<List<int>> linqOptimizerQuery;

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
    public List<int> ForLoop()
    {
        var list = new List<int>();
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
    public List<int> ForeachLoop()
    {
        var list = new List<int>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public List<int> Linq()
        => System.Linq.Enumerable.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

    [Benchmark]
    public List<int> LinqFaster()
        => new(source.WhereSelectF(item => item.IsEven(), item => item * 3));

    [Benchmark]
    public List<int> LinqFasterer()
        => EnumerableF.ToListF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );

    [Benchmark]
    public List<int> LinqAF()
        => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

    [Benchmark]
    public List<int> LinqOptimizer()
        => linqOptimizerQuery.Invoke();

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public List<int> SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();
#endif
    
    [Benchmark]
    public List<int> Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> StructLinq()
        => source
            .ToStructEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var selector = new TripleOfInt32();
        return source
            .ToStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToList(x => x);
    }

    [Benchmark]
    public List<int> Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<Int32IsEven>()
            .Select<int, TripleOfInt32>()
            .ToList();

    [Benchmark]
    public List<int> Faslinq() 
        => ListExtensions.WhereSelect(
                source, 
                item => item.IsEven(), 
                item => item * 3);
}
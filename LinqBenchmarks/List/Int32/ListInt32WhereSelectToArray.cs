using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.Int32;

public partial class ListInt32WhereSelectToArray: Int32ListBenchmarkBase
{
    Func<int[]> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source.AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray()
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public int[] ForLoop()
    {
        var list = new List<int>();
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
    public int[] ForeachLoop()
    {
        var list = new List<int>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list.ToArray();
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int[] Linq()
        => System.Linq.Enumerable
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] LinqFaster()
        => source
            .WhereSelectF(item => item.IsEven(), item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] LinqFasterer()
        => EnumerableF.ToArrayF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );

    [Benchmark]
    public int[] LinqAF()
        => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToArray();

    [Benchmark]
    public int[] LinqOptimizer()
        => linqOptimizerQuery.Invoke();

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public int[] SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();
#endif
    
    [Benchmark]
    public int[] Streams()
        => source.AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] StructLinq()
        => source.ToStructEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var selector = new TripleOfInt32();
        return source
            .ToStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToArray(x => x);
    }

    [Benchmark]
    public int[] Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<Int32IsEven>()
            .Select<int, TripleOfInt32>()
            .ToArray();

    [Benchmark]
    public int[] Faslinq() 
        => ListExtensions.WhereSelect(
                source, 
                item => item.IsEven(), 
                item => item * 3)
            .ToArray();
}
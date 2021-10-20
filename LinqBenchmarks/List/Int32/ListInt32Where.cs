using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

namespace LinqBenchmarks.List.Int32;

public class ListInt32Where: Int32ListBenchmarkBase
{
    Func<IEnumerable<int>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var sum = 0;
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (item.IsEven())
                sum += item;
        }
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
        {
            if (item.IsEven())
                sum += item;
        }
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int Linq()
    {
        var items = System.Linq.Enumerable.Where(source, item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFaster()
    {
        var items = source.WhereF(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.WhereF(source, item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqOptimizer()
    {
        var items = linqOptimizerQuery.Invoke();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public int SpanLinq()
    {
        var items = CollectionsMarshal.AsSpan(source)
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
#endif
    
    [Benchmark]
    public int Streams()
    {
        var items = source
            .AsStream()
            .Where(item => item.IsEven())
            .ToEnumerable();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq()
    {
        var items = source
            .ToStructEnumerable()
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var items = source
            .ToStructEnumerable()
            .Where(ref predicate, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable()
            .Where<Int32IsEven>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Faslinq()
    {
        var items = 
            ListExtensions.Where(source, item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
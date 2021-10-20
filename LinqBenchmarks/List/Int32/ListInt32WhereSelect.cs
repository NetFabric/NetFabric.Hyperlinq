using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator

namespace LinqBenchmarks.List.Int32;

public class ListInt32WhereSelect: Int32ListBenchmarkBase
{
    Func<IEnumerable<int>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
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
                sum += item * 3;
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
                sum += item * 3;
        }
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int Linq()
    {
        var items = source
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFaster()
    {
        var items = source.WhereSelectF(item => item.IsEven(), item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.SelectF(EnumerableF.WhereF(source, item => item.IsEven()), item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3);
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
            .Where(item => item.IsEven())
            .Select(item => item * 3);
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
            .Select(item => item * 3)
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
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var selector = new TripleOfInt32();
        var items = source
            .ToStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable()
            .Where<Int32IsEven>()
            .Select<int, TripleOfInt32>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Faslinq()
    {
        var items = 
            ListExtensions.WhereSelect(
                source, 
                item => item.IsEven(), 
                item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
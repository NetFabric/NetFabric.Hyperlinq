using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis.Host;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.Int32;

public class ListInt32Select: Int32ListBenchmarkBase
{
    Func<IEnumerable<int>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Select(item => item * 3)
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var sum = 0;
        for (var index = 0; index < source.Count; index++)
            sum += source[index] * 3;
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
            sum += item * 3;
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int Linq()
    {
        var items = System.Linq.Enumerable.Select(source, item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFaster()
    {
        var items = source.SelectF(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.SelectF(source, item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Select(source, item => item * 3);
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
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var selector = new TripleOfInt32();
        var items = source
            .ToStructEnumerable()
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
            ListExtensions.Select(source, item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

}
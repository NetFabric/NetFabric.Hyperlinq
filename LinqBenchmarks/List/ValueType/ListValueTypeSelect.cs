using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery

namespace LinqBenchmarks.List.ValueType;

public class ListValueTypeSelect: ValueTypeListBenchmarkBase
{
    Func<IEnumerable<FatValueType>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Select(item => item * 3)
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public FatValueType ForLoop()
    {
        var sum = default(FatValueType);
        for (var index = 0; index < source.Count; index++)
            sum += source[index] * 3;
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public FatValueType ForeachLoop()
    {
        var sum = default(FatValueType);
        foreach (var item in source)
            sum += item * 3;
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public FatValueType Linq()
    {
        var items = System.Linq.Enumerable.Select(source, item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFaster()
    {
        var items = source.SelectF(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFasterer()
    {
        var items = EnumerableF.SelectF(source, item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Select(source, item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqOptimizer()
    {
        var items = linqOptimizerQuery.Invoke();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public FatValueType SpanLinq()
    {
        var items = CollectionsMarshal.AsSpan(source)
            .Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }
#endif
    
    [Benchmark]
    public FatValueType Streams()
    {
        var items = source
            .AsStream()
            .Select(item => item * 3)
            .ToEnumerable();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType StructLinq()
    {
        var items = source
            .ToRefStructEnumerable()
            .Select((in FatValueType item) => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType StructLinq_ValueDelegate()
    {
        var selector = new TripleOfFatValueType();
        var items = source
            .ToRefStructEnumerable()
            .Select(ref selector, x => x, x => x);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq()
    {
        var items = source.AsValueEnumerable().Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable().Select<FatValueType, TripleOfFatValueType>();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Faslinq()
    {
        var items = 
            ListExtensions.Select(source, item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
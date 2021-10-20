using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach

namespace LinqBenchmarks.List.ValueType;

public class ListValueTypeWhereSelect: ValueTypeListBenchmarkBase
{
    Func<IEnumerable<FatValueType>> linqOptimizerQuery;

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
    public FatValueType ForLoop()
    {
        var sum = default(FatValueType);
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (item.IsEven())
                sum += (item * 3);
        }
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public FatValueType ForeachLoop()
    {
        var sum = default(FatValueType);
        foreach (var item in source)
        {
            if (item.IsEven())
                sum += (item * 3);
        }
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public FatValueType Linq()
    {
        var items = System.Linq.Enumerable
            .Where(source, item => item.IsEven())
            .Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFaster()
    {
        var items = source.WhereSelectF(item => item.IsEven(), item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFasterer()
    {
        var items = EnumerableF.SelectF(EnumerableF.WhereF(source, item => item.IsEven()), item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods
            .Where(source, item => item.IsEven())
            .Select(item => item * 3);
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
            .Where(item => item.IsEven())
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
            .Where(item => item.IsEven())
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
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType StructLinq_ValueDelegate()
    {
        var predicate = new FatValueTypeIsEven();
        var selector = new TripleOfFatValueType();
        var items = source
            .ToRefStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable()
            .Where<FatValueTypeIsEven>()
            .Select<FatValueType, TripleOfFatValueType>();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Faslinq()
    {
        var items = 
            ListExtensions.WhereSelect(
                source, 
                item => item.IsEven(), 
                item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }}
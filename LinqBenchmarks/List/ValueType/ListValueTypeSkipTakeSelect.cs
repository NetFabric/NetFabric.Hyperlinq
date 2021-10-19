using System.Runtime.InteropServices;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery

namespace LinqBenchmarks.List.ValueType;

public class ListValueTypeSkipTakeSelect: ValueTypeListSkipTakeBenchmarkBase
{
    Func<IEnumerable<FatValueType>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Skip(Skip)
            .Take(Count)
            .Select(item => item * 3)
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public FatValueType ForLoop()
    {
        var sum = default(FatValueType);
        var end = Skip + Count;
        for (var index = Skip; index < end; index++)
            sum += source[index] * 3;
        return sum;
    }

    [Benchmark]
    public FatValueType Linq()
    {
        var items = source.Skip(Skip).Take(Count).Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFaster()
    {
        var items = source.SkipF(Skip).TakeF(Count).SelectF(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFasterer()
    {
        var items = EnumerableF.SelectF(EnumerableF.TakeF(EnumerableF.SkipF(source, Skip), Count), item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 3);
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
            .Skip(Skip)
            .Take(Count)
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
            .Skip(Skip)
            .Take(Count)
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
            .Skip(Skip)
            .Take(Count)
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
            .Skip(Skip, x => x)
            .Take(Count, x => x)
            .Select(ref selector, x=> x, x => x);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
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
            .Skip(Skip)
            .Take(Count)
            .Select<FatValueType, TripleOfFatValueType>();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
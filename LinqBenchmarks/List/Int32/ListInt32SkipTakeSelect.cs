using System.Runtime.InteropServices;

namespace LinqBenchmarks.List.Int32;

public class ListInt32SkipTakeSelect: Int32ListSkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var sum = 0;
        var end = Skip + Count;
        for (var index = Skip; index < end; index++)
            sum += source[index] * 3;
        return sum;
    }

    [Benchmark]
    public int Linq()
    {
        var items = System.Linq.Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFaster()
    {
        var items = source.SkipF(Skip).TakeF(Count).SelectF(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.SelectF(EnumerableF.TakeF(EnumerableF.SkipF(source, Skip), Count), item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 3);
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
            .Skip(Skip)
            .Take(Count)
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
#endif

    [Benchmark]
    public int StructLinq()
    {
        var items = source
            .ToStructEnumerable()
            .Skip(Skip)
            .Take(Count)
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
            .Skip(Skip, x=> x)
            .Take(Count, x => x)
            .Select(ref selector, x=> x, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable().Skip(Skip).Take(Count).Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable().Skip(Skip).Take(Count).Select<int, TripleOfInt32>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
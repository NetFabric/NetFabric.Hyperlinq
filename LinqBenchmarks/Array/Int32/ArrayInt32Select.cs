

// ReSharper disable LoopCanBeConvertedToQuery

using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.Int32;

public class ArrayInt32Select: ArrayInt32BenchmarkBase
{
    Func<IEnumerable<int>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source.AsQueryExpr().Select(item => item * 3).Compile();
    }

    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var sum = 0;
        var array = source;
        for (var index = 0; index < array.Length; index++)
            sum += array[index] * 3;
        return sum;
    }

    [Benchmark]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
            sum += item * 3;
        return sum;
    }

    [Benchmark]
    public int Linq()
    {
        var items = source.Select(item => item * 3);
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
    public int LinqFaster_SIMD()
    {
        var items = source.SelectS(item => item * 3, item => item * 3);
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
        var items = global::LinqAF.ArrayExtensionMethods.Select(source, item => item * 3);
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

    [Benchmark]
    public int SpanLinq()
    {
        var items = source.AsSpan().Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Streams()
    {
        var items = source.AsStream().Select(item => item * 3).ToEnumerable();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq()
    {
        var items = source.ToStructEnumerable().Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var selector = new TripleOfInt32();
        var items = source.ToStructEnumerable().Select(ref selector, x => x, x => x);
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
            ArrayExtensions.Select(
                source, 
                item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

}
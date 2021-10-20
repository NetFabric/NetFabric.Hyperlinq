using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.Int32;

public class ArrayInt32WhereSelect: ArrayInt32BenchmarkBase
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
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (item.IsEven())
                sum += item * 3;
        }
        return sum;
    }

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

    [Benchmark]
    public int Linq()
    {
        var items = source.Where(item => item.IsEven()).Select(item => item * 3);
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
        var items = global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3);
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
        var items = source
            .AsSpan()
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

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
            ArrayExtensions.WhereSelect(
                    source,
                    item => item.IsEven(),
                    item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
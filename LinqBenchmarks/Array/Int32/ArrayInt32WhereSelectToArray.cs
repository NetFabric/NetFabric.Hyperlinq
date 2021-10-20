using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.Int32;

public partial class ArrayInt32WhereSelectToArray: ArrayInt32BenchmarkBase
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
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list.ToArray();
    }

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

    [Benchmark]
    public int[] Linq()
        => source
            .Where(item => item.IsEven()).Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] LinqFaster()
        => source
            .WhereSelectF(item => item.IsEven(), item => item * 3);

    [Benchmark]
    public int[] LinqFasterer()
        => EnumerableF.ToArrayF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );
            
    [Benchmark]
    public int[] LinqAF()
        => global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToArray();

    [Benchmark]
    public int[] LinqOptimizer()
        => linqOptimizerQuery.Invoke();

    [Benchmark]
    public int[] SpanLinq()
        => source.AsSpan()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToArray();

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
        return source.ToStructEnumerable()
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
        => ArrayExtensions.WhereSelect(
            source,
            item => item.IsEven(),
            item => item * 3);
}
using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.Int32;

public class ArrayInt32WhereCount: ArrayInt32BenchmarkBase
{
    Func<int> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup(); 

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Count()
            .Compile();            
    }
        
    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var count = 0;
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (item.IsEven())
                count++;
        }
        return count;
    }

    [Benchmark]
    public int ForeachLoop()
    {
        var count = 0;
        foreach (var item in source)
        {
            if (item.IsEven())
                count++;
        }
        return count;
    }

    [Benchmark]
    public int Linq()
        => source.Count(item => item.IsEven());

    [Benchmark]
    public int LinqFaster()
        => source.CountF(item => item.IsEven());

    [Benchmark]
    public int LinqFasterer()
        => EnumerableF.CountF(source, item => item.IsEven());

    [Benchmark]
    public int LinqAF()
        => global::LinqAF.ArrayExtensionMethods.Count(source, item => item.IsEven());

    [Benchmark]
    public int LinqOptimizer()
        => linqOptimizerQuery.Invoke();

    [Benchmark]
    public int SpanLinq()
        => source
            .AsSpan()
            .Where(item => item.IsEven())
            .Count();

    [Benchmark]
    public int Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Count();

    [Benchmark]
    public int StructLinq()
        => source
            .ToStructEnumerable()
            .Where(item => item.IsEven())
            .Count();

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        return source
            .ToStructEnumerable()
            .Where(ref predicate, x => x)
            .Count(x => x);
    }

    [Benchmark]
    public int Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Count();

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<Int32IsEven>()
            .Count();

    [Benchmark]
    public int Faslinq()
        => ArrayExtensions
            .Where(source, item => item.IsEven())
            .Count();
}
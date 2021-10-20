// ReSharper disable ForCanBeConvertedToForeach

using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.ValueType;

public partial class ArrayValueTypeWhereSelectToList: ValueTypeArrayBenchmarkBase
{
    Func<List<FatValueType>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList()
            .Compile();
    }
        
    [Benchmark(Baseline = true)]
    public List<FatValueType> ForLoop()
    {
        var list = new List<FatValueType>();
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            ref readonly var item = ref array[index];
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }

    [Benchmark]
    public List<FatValueType> ForeachLoop()
    {
        var list = new List<FatValueType>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }

    [Benchmark]
    public List<FatValueType> Linq()
        => System.Linq.Enumerable
            .Where(source, item => item.IsEven()).Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> LinqFaster()
        => new(source
            .WhereSelectF(item => item.IsEven(), item => item * 3));

    [Benchmark]
    public List<FatValueType> LinqFasterer()
        => EnumerableF.ToListF(
            EnumerableF.SelectF(
                EnumerableF.WhereF(source, item => item.IsEven()), 
                item => item * 3)
        );

    [Benchmark]
    public List<FatValueType> LinqAF()
        => global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

    [Benchmark]
    public List<FatValueType> LinqOptimizer()
        => linqOptimizerQuery.Invoke();

    [Benchmark]
    public List<FatValueType> SpanLinq()
        => source
            .AsSpan()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> StructLinq()
        => source
            .ToRefStructEnumerable()
            .Where((in FatValueType item) => item.IsEven())
            .Select((in FatValueType item) => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> StructLinq_ValueDelegate()
    {
        var predicate = new FatValueTypeIsEven();
        var selector = new TripleOfFatValueType();
        return source.ToRefStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToList(x => x);
    }

    [Benchmark]
    public List<FatValueType> Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<FatValueType> Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<FatValueTypeIsEven>()
            .Select<FatValueType, TripleOfFatValueType>()
            .ToList();

    [Benchmark]
    public List<FatValueType> Faslinq()
        => ArrayExtensions.WhereSelect(
                source,
                item => item.IsEven(),
                item => item * 3)
            .ToList();
}
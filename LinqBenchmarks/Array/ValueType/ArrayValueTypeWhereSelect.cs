using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.ValueType;

public class ArrayValueTypeWhereSelect: ValueTypeArrayBenchmarkBase
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
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            ref readonly var item = ref array[index];
            if (item.IsEven())
                sum += item * 3;
        }
        return sum;
    }

    [Benchmark]
    public FatValueType ForeachLoop()
    {
        var sum = default(FatValueType);
        foreach (var item in source)
        {
            if (item.IsEven())
                sum += item * 3;
        }
        return sum;
    }

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
        var items = global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3);
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

    [Benchmark]
    public FatValueType SpanLinq()
    {
        var items = source
            .AsSpan()
            .Where(item => item.IsEven())
            .Select(item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

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
            ArrayExtensions.WhereSelect(
                source,
                item => item.IsEven(),
                item => item * 3);
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
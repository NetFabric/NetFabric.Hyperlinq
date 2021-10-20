// ReSharper disable LoopCanBeConvertedToQuery

using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.ValueType;

public class ArrayValueTypeWhere: ValueTypeArrayBenchmarkBase
{
    Func<IEnumerable<FatValueType>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
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
                sum += item;
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
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public FatValueType Linq()
    {
        var items = System.Linq.Enumerable.Where(source, item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFaster()
    {
        var items = source.WhereF(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFasterer()
    {
        var items = EnumerableF.WhereF(source, item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqAF()
    {
        var items = global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven());
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
        var fatValueTypes = source
            .AsSpan()
            .Where(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in fatValueTypes)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Streams()
    {
        var fatValueTypes = source
            .AsStream()
            .Where(item => item.IsEven())
            .ToEnumerable();
        var sum = default(FatValueType);
        foreach (var item in fatValueTypes)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType StructLinq()
    {
        var items = source
            .ToRefStructEnumerable()
            .Where((in FatValueType item) => item.IsEven());
        var sum = default(FatValueType);
        foreach (ref readonly var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType StructLinq_ValueDelegate()
    {
        var predicate = new FatValueTypeIsEven();
        var items = source
            .ToRefStructEnumerable()
            .Where(ref predicate, x => x);
        var sum = default(FatValueType);
        foreach (ref readonly var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Where(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable()
            .Where<FatValueTypeIsEven>();
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Faslinq()
    {
        var items = 
            ArrayExtensions.Where(source, item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }
}
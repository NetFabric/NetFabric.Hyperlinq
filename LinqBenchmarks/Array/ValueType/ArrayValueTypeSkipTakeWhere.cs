namespace LinqBenchmarks.Array.ValueType;

public class ArrayValueTypeSkipTakeWhere: ValueTypeArraySkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public FatValueType ForLoop()
    {
        var sum = default(FatValueType);
        var end = Skip + Count;
        for (var index = Skip; index < end; index++)
        {
            ref readonly var item = ref source[index];
            if (item.IsEven())
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public FatValueType Linq()
    {
        var items = System.Linq.Enumerable.Skip(source, Skip).Take(Count).Where(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFaster()
    {
        var items = source.SkipF(Skip).TakeF(Count).WhereF(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqFasterer()
    {
        var items = EnumerableF.WhereF(EnumerableF.TakeF(EnumerableF.SkipF(source, Skip), Count), item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType LinqAF()
    {
        var items = global::LinqAF.ArrayExtensionMethods.Skip(source, Skip).Take(Count).Where(item => item.IsEven());
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
            .Skip(Skip, x=> x)
            .Take(Count, x=> x)
            .Where(ref predicate, x=> x);
        var sum = default(FatValueType);
        foreach (ref readonly var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq()
    {
        var arraySegmentWhereEnumerable = source.AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven());
        var sum = default(FatValueType);
        foreach (var item in arraySegmentWhereEnumerable)
            sum += item;
        return sum;
    }

    [Benchmark]
    public FatValueType Hyperlinq_ValueDelegate()
    {
        var arraySegmentWhereEnumerable = source.AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where<FatValueTypeIsEven>();
        var sum = default(FatValueType);
        foreach (var item in arraySegmentWhereEnumerable)
            sum += item;
        return sum;
    }
}
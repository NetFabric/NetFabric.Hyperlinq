using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.ValueType;

public class ListValueTypeContains : ValueTypeListBenchmarkBase
{
    FatValueType value = new(int.MaxValue);

    [Benchmark(Baseline = true)]
    public bool ForLoop()
    {
        var array = source;
        for (var index = 0; index < array.Count; index++)
        {
            var item = array[index];
            if (item == value)
                return true;
        }
        return false;
    }

    [Benchmark]
    public bool ForeachLoop()
    {
        foreach (var item in source)
        {
            if (item == value)
                return true;
        }
        return false;
    }

    [Benchmark]
    public bool Linq()
        => System.Linq.Enumerable.Contains(source, value);

    [Benchmark]
    public bool LinqFaster()
        => source.ContainsF(value);

    [Benchmark]
    public bool LinqFasterer()
        => EnumerableF.ContainsF(source, value);

    [Benchmark]
    public bool LinqAF()
        => global::LinqAF.ListExtensionMethods.Contains(source, value);

    [Benchmark]
    public bool StructLinq()
        => source
            .ToRefStructEnumerable()
            .Contains(value);

    [Benchmark]
    public bool StructLinq_ValueDelegate()
        => source
            .ToRefStructEnumerable()
            .Contains(value, x => x);

    [Benchmark]
    public bool Hyperlinq()
        => source.AsValueEnumerable()
            .Contains(value);

    [Benchmark]
    public bool Faslinq()
        => ListExtensions.Any(source, i => i.Equals(value));
}
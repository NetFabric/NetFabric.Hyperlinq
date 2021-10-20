using ArrayExtensions = Faslinq.ArrayExtensions;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.Int32;

public partial class ListInt32Contains: Int32ListBenchmarkBase
{
    int value = int.MaxValue;

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
        return true;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public bool ForeachLoop()
    {
        foreach (var item in source)
        {
            if (item == value)
                return true;
        }
        return true;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public bool Linq()
        => System.Linq.Enumerable
            .Contains(source, value);

    [Benchmark]
    public bool LinqFaster()
        => source
            .ContainsF(value);

    [Benchmark]
    public bool LinqFasterer()
        => EnumerableF.ContainsF(source, value);

    [Benchmark]
    public bool LinqAF()
        => global::LinqAF.ListExtensionMethods.Contains(source, value);

    [Benchmark]
    public bool StructLinq()
        => source
            .ToStructEnumerable()
            .Contains(value);

    [Benchmark]
    public bool StructLinq_ValueDelegate()
        => source
            .ToStructEnumerable()
            .Contains(value, x => x);

    [Benchmark]
    public bool Hyperlinq()
        => source
            .AsValueEnumerable()
            .Contains(value);

    [Benchmark]
    public bool Hyperlinq_SIMD()
        => source
            .AsValueEnumerable()
            .ContainsVector(value);

    [Benchmark]
    public bool Faslinq()
        => ListExtensions.Any(source, i => i.Equals(value));
}
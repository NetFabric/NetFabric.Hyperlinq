using ArrayExtensions = Faslinq.ArrayExtensions;

namespace LinqBenchmarks.Array.Int32;

public class ArrayInt32Contains: ArrayInt32BenchmarkBase
{
    int value = int.MaxValue;

    [Benchmark(Baseline = true)]
    public bool ForLoop()
    {
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (item == value)
                return true;
        }
        return true;
    }

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

    [Benchmark]
    public bool Linq()
        => source
            .Contains(value);

    [Benchmark]
    public bool LinqFaster()
        => source.ContainsF(value);

    [Benchmark]
    public bool LinqFaster_SIMD()
        => source.ContainsS(value);

    [Benchmark]
    public bool LinqFasterer()
        => EnumerableF.ContainsF(source, value);

    [Benchmark]
    public bool LinqAF()
        => global::LinqAF.ArrayExtensionMethods
            .Contains(source, value);

    [Benchmark]
    public bool StructLinq()
        => source
            .ToStructEnumerable()
            .Contains(value);

    [Benchmark]
    public bool StructLinq_ValueDelegate()
    {
        return source
            .ToStructEnumerable()
            .Contains(value, x => x);
    }

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
        => ArrayExtensions.Any(source, i => i.Equals(value));
}
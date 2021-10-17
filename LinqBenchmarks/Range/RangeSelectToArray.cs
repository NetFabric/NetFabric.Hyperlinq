namespace LinqBenchmarks.Range;

public partial class RangeSelectToArray : RangeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int[] ForLoop()
    {
        var array = new int[Count];
        for (var index = 0; index < Count; index++)
            array[index] = (index + Start) * 3;
        return array;
    }

    [Benchmark]
    public int[] Linq()
        => System.Linq.Enumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] LinqFaster()
        => JM.LinqFaster.LinqFaster
            .RangeArrayF(Start, Count)
            .SelectF(item => item * 3);

    [Benchmark]
    public int[] LinqFaster_SIMD()
        => LinqFasterSIMD
            .RangeS(Start, Count)
            .SelectS(item => item * 3, item => item * 3);

    [Benchmark]
    public int[] LinqAF()
        => global::LinqAF.Enumerable
            .Range(Start, Count).Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] StructLinq()
        => StructEnumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] StructLinq_ValueDelegate()
    {
        var selector = new TripleOfInt32();
        return StructEnumerable
            .Range(Start, Count)
            .Select(ref selector, x => x, x => x)
            .ToArray(x => x);
    }

    [Benchmark]
    public int[] Hyperlinq()
        => ValueEnumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] Hyperlinq_ValueDelegate()
        => ValueEnumerable
            .Range(Start, Count)
            .Select<int, TripleOfInt32>()
            .ToArray();

    [Benchmark]
    public int[] Hyperlinq_SIMD()
        => ValueEnumerable
            .Range(Start, Count)
            .SelectVector(item => item * 3, item => item * 3)
            .ToArray();

    [Benchmark]
    public int[] Hyperlinq_ValueDelegate_SIMD()
        => ValueEnumerable
            .Range(Start, Count)
            .SelectVector<int, TripleOfInt32>()
            .ToArray();
}
namespace LinqBenchmarks.Range;

public partial class RangeToArray: RangeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int[] ForLoop()
    {
        var array = new int[Count];
        for (var index = 0; index < Count; index++)
            array[index] = index + Start;
        return array;
    }

    [Benchmark]
    public int[] Linq()
        => System.Linq.Enumerable
            .Range(Start, Count).ToArray();

    [Benchmark]
    public int[] LinqFaster()
        => JM.LinqFaster.LinqFaster
            .RangeArrayF(Start, Count);

    [Benchmark]
    public int[] LinqFaster_SIMD()
        => LinqFasterSIMD
            .RangeS(Start, Count);

    [Benchmark]
    public int[] LinqAF()
        => global::LinqAF.Enumerable
            .Range(Start, Count)
            .ToArray();

    [Benchmark]
    public int[] StructLinq()
        => StructEnumerable
            .Range(Start, Count)
            .ToArray(x => x);

    [Benchmark]
    public int[] Hyperlinq()
        => ValueEnumerable
            .Range(Start, Count)
            .ToArray();
}
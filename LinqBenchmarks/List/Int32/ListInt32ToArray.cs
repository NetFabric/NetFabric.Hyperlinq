using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.Int32;

public partial class ListInt32ToArray: Int32ListBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int[] List_ToArray() 
        => source.ToArray();

    [Benchmark]
    public int[] Linq()
        => System.Linq.Enumerable
            .ToArray(source);

    [Benchmark]
    public int[] LinqFasterer()
        => EnumerableF.ToArrayF(source);

    [Benchmark]
    public int[] LinqAF()
        => global::LinqAF.ListExtensionMethods.ToArray(source);

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public int[] SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .ToArray();
#endif

    [Benchmark]
    public int[] StructLinq()
        => source.ToStructEnumerable()
            .ToArray();

    [Benchmark]
    public int[] StructLinq_ValueDelegate() 
        => source
            .ToStructEnumerable()
            .ToArray(x => x);

    [Benchmark]
    public int[] Hyperlinq()
        => source.AsValueEnumerable()
            .ToArray();

    [Benchmark]
    public int[] Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .ToArray();
}
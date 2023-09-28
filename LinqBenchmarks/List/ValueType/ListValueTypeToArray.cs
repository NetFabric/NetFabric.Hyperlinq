using System.Runtime.InteropServices;
using ListExtensions = Faslinq.ListExtensions;

namespace LinqBenchmarks.List.ValueType;

public partial class ListValueTypeToArray: ValueTypeListBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public FatValueType[] List_ToArray()
        => source.ToArray();

    [Benchmark]
    public FatValueType[] Linq()
        => System.Linq.Enumerable
            .ToArray(source);

    [Benchmark]
    public FatValueType[] LinqFasterer()
        => EnumerableF.ToArrayF(source);

    [Benchmark]
    public FatValueType[] LinqAF()
        => global::LinqAF.ListExtensionMethods
            .ToArray(source);

#if DOTNET5_0_OR_GREATER
    [Benchmark]
    public FatValueType[] SpanLinq()
        => CollectionsMarshal.AsSpan(source)
            .ToArray();
#endif

    [Benchmark]
    public FatValueType[] StructLinq()
        => source
            .ToRefStructEnumerable()
            .ToArray();

    [Benchmark]
    public FatValueType[] StructLinq_ValueDelegate() 
        => source.ToRefStructEnumerable()
            .ToArray(x => x);

    [Benchmark]
    public FatValueType[] Hyperlinq()
        => source.AsValueEnumerable()
            .ToArray();

    [Benchmark]
    public FatValueType[] Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .ToArray();
}
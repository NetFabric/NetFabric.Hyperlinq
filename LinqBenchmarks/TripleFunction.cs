using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace LinqBenchmarks;

readonly struct TripleOfInt32
    // : Cistern.ValueLinq.IFunc<int, int>
    : StructLinq.IFunction<int, int>
        , NetFabric.Hyperlinq.IFunction<int, int>
        , NetFabric.Hyperlinq.IFunction<Vector<int>, Vector<int>>
        , NetFabric.Hyperlinq.IAsyncFunction<int, int>
{
    // ValueLinq
    // int Cistern.ValueLinq.IFunc<int, int>.Invoke(int item) 
    //     => item * 3;
        
    // StructLinq
    int StructLinq.IFunction<int, int>.Eval(int item)
        => item * 3;

    // Hyperlinq
    int NetFabric.Hyperlinq.IFunction<int, int>.Invoke(int item)
        => item * 3;

    Vector<int> NetFabric.Hyperlinq.IFunction<Vector<int>, Vector<int>>.Invoke(Vector<int> item)
        => item * 3;

    ValueTask<int> NetFabric.Hyperlinq.IAsyncFunction<int, int>.InvokeAsync(int item, CancellationToken cancellationToken)
        => new (item * 3);
}

readonly struct TripleOfFatValueType
    // : Cistern.ValueLinq.IFunc<FatValueType, FatValueType>
    : StructLinq.IInFunction<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IFunction<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IFunctionIn<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IAsyncFunction<FatValueType, FatValueType>
{
    // ValueLinq
    // FatValueType Cistern.ValueLinq.IFunc<FatValueType, FatValueType>.Invoke(FatValueType item) 
    //     => item * 3;
        
    // StructLinq
    FatValueType StructLinq.IInFunction<FatValueType, FatValueType>.Eval(in FatValueType item)
        => item * 3;

    // Hyperlinq
    FatValueType NetFabric.Hyperlinq.IFunction<FatValueType, FatValueType>.Invoke(FatValueType item)
        => item * 3;

    FatValueType NetFabric.Hyperlinq.IFunctionIn<FatValueType, FatValueType>.Invoke(in FatValueType item)
        => item * 3;

    ValueTask<FatValueType> NetFabric.Hyperlinq.IAsyncFunction<FatValueType, FatValueType>.InvokeAsync(FatValueType item, CancellationToken cancellationToken)
        => new (item * 3);
}
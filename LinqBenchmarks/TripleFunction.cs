using System.Numerics;

namespace LinqBenchmarks
{
    readonly struct TripleOfInt32
        : Cistern.ValueLinq.IFunc<int, int>
        , StructLinq.IFunction<int, int>
        , NetFabric.Hyperlinq.IFunction<int, int>
        , NetFabric.Hyperlinq.IFunction<Vector<int>, Vector<int>>
    {
        // ValueLinq
        int Cistern.ValueLinq.IFunc<int, int>.Invoke(int element) 
            => element * 3;
        
        // StructLinq
        int StructLinq.IFunction<int, int>.Eval(int element)
            => element * 3;

        // Hyperlinq
        int NetFabric.Hyperlinq.IFunction<int, int>.Invoke(int element)
            => element * 3;

        // Hyperlinq
        Vector<int> NetFabric.Hyperlinq.IFunction<Vector<int>, Vector<int>>.Invoke(Vector<int> element)
            => element * 3;
    }

    readonly struct TripleOfFatValueType
        : Cistern.ValueLinq.IFunc<FatValueType, FatValueType>
        , StructLinq.IInFunction<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IFunction<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IFunctionIn<FatValueType, FatValueType>
    {
        // ValueLinq
        FatValueType Cistern.ValueLinq.IFunc<FatValueType, FatValueType>.Invoke(FatValueType element) 
            => element * 3;
        
        // StructLinq
        FatValueType StructLinq.IInFunction<FatValueType, FatValueType>.Eval(in FatValueType element)
            => element * 3;

        // Hyperlinq
        FatValueType NetFabric.Hyperlinq.IFunction<FatValueType, FatValueType>.Invoke(FatValueType element)
            => element * 3;

        // Hyperlinq
        FatValueType NetFabric.Hyperlinq.IFunctionIn<FatValueType, FatValueType>.Invoke(in FatValueType element)
            => element * 3;
    }
}

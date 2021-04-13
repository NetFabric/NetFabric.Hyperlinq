namespace LinqBenchmarks
{
    readonly struct Int32IsEven
        // : Cistern.ValueLinq.IFunc<int, bool>
        : StructLinq.IFunction<int, bool>
        , NetFabric.Hyperlinq.IFunction<int, bool>
    {
        // ValueLinq
        // bool Cistern.ValueLinq.IFunc<int, bool>.Invoke(int item) 
        //     => item.IsEven();
        
        // StructLinq
        bool StructLinq.IFunction<int, bool>.Eval(int item)
            => item.IsEven();

        // Hyperlinq
        bool NetFabric.Hyperlinq.IFunction<int, bool>.Invoke(int item)
            => item.IsEven();
    }

    readonly struct FatValueTypeIsEven
        // : Cistern.ValueLinq.IFunc<FatValueType, bool>
        : StructLinq.IInFunction<FatValueType, bool>
        , NetFabric.Hyperlinq.IFunction<FatValueType, bool>
        , NetFabric.Hyperlinq.IFunctionIn<FatValueType, bool>
    {
        // ValueLinq
        // bool Cistern.ValueLinq.IFunc<FatValueType, bool>.Invoke(FatValueType item) 
        //     => item.IsEven();
        
        // StructLinq
        bool StructLinq.IInFunction<FatValueType, bool>.Eval(in FatValueType item)
            => item.IsEven();

        // Hyperlinq
        bool NetFabric.Hyperlinq.IFunction<FatValueType, bool>.Invoke(FatValueType item)
            => item.IsEven();

        // Hyperlinq
        bool NetFabric.Hyperlinq.IFunctionIn<FatValueType, bool>.Invoke(in FatValueType item)
            => item.IsEven();
    }
}

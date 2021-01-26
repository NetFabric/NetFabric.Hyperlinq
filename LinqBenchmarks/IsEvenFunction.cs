namespace LinqBenchmarks
{
    readonly struct Int32IsEven
        : StructLinq.IFunction<int, bool>
        , NetFabric.Hyperlinq.IFunction<int, bool>
    {
        public bool Eval(int element)
            => element.IsEven();

        public bool Invoke(int element)
            => element.IsEven();
    }

    readonly struct FatValueTypeIsEven
        : StructLinq.IInFunction<FatValueType, bool>
        , NetFabric.Hyperlinq.IFunction<FatValueType, bool>
    {
        public bool Eval(in FatValueType element)
            => element.Value0.IsEven();

        public bool Invoke(FatValueType element)
            => element.Value0.IsEven();
    }
}

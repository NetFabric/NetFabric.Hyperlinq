namespace LinqBenchmarks
{
    readonly struct DoubleOfInt32
        : StructLinq.IFunction<int, int>
        , NetFabric.Hyperlinq.IFunction<int, int>
    {
        public int Eval(int element)
            => element * 2;

        public int Invoke(int element)
            => element * 2;
    }

    readonly struct DoubleOfFatValueType
        : StructLinq.IInFunction<FatValueType, FatValueType>
        , NetFabric.Hyperlinq.IFunction<FatValueType, FatValueType>
    {
        public FatValueType Eval(in FatValueType element)
            => element * 2;

        public FatValueType Invoke(FatValueType element)
            => element * 2;
    }
}

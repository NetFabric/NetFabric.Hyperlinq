namespace LinqBenchmarks
{
    readonly struct Value0Selector
        : StructLinq.IInFunction<FatValueType, int>
        , NetFabric.Hyperlinq.IFunction<FatValueType, int>
        , NetFabric.Hyperlinq.IFunctionIn<FatValueType, int>
    {
        public int Eval(in FatValueType element)
            => element.Value0;

        public int Invoke(FatValueType element)
            => element.Value0;

        public int Invoke(in FatValueType element)
            => element.Value0;
    }
}

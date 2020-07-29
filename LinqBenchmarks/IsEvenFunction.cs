using StructLinq;

namespace LinqBenchmarks
{
    readonly struct Int32IsEven
        : IFunction<int, bool>
    {
        public bool Eval(int element)
            => element.IsEven();
    }

    readonly struct FatValueTypeIsEven
        : IInFunction<FatValueType, bool>
    {
        public bool Eval(in FatValueType element)
            => element.Value0.IsEven();
    }
}

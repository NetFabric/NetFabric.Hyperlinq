using StructLinq;

namespace LinqBenchmarks
{
    readonly struct DoubleOfInt32
        : IFunction<int, int>
    {
        public int Eval(int element)
            => element * 2;
    }

    readonly struct DoubleOfFatValueType
        : IInFunction<FatValueType, FatValueType>
    {
        public FatValueType Eval(in FatValueType element)
            => element * 2;
    }
}

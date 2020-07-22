using StructLinq;

namespace LinqBenchmarks
{
    struct DoubleOfInt32
        : IFunction<int, int>
    {
        public int Eval(int element)
            => element * 2;
    }

    struct DoubleOfFatValueType
        : IInFunction<FatValueType, FatValueType>
    {
        public FatValueType Eval(in FatValueType element)
            => new FatValueType(element.Value0 * 2);
    }
}

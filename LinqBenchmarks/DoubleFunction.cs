using StructLinq;

namespace LinqBenchmarks
{
    struct DoubleFunction : IFunction<int, int>
    {
        public int Eval(int element)
            => element * 2;
    }
}

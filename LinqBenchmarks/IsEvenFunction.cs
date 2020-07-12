using StructLinq;

namespace LinqBenchmarks
{
    struct IsEvenFunction : IFunction<int, bool>
    {
        public bool Eval(int element)
            => element.IsEven();
    }
}

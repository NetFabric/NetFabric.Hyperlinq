using StructLinq;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks
{
    readonly struct Int32IsEven
        : IPredicate<int>
        , IFunction<int, bool>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke(int item) 
            => item.IsEven();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Eval(int element)
            => element.IsEven();
    }
}

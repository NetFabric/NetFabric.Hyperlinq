using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks
{
    struct IsEven 
        : IFunction<int, bool>
        , StructLinq.IFunction<int, bool>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke(int element) 
            => (element & 0x01) == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Eval(int element) 
            => (element & 0x01) == 0;
    }

    struct Double 
        : IFunction<int, int>
        , StructLinq.IFunction<int, int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(int element) 
            => element * 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Eval(int element) 
            => element * 2;
    }
}
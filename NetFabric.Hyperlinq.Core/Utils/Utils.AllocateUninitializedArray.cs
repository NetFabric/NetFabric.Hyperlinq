using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AllocateUninitializedArray<T>(int count)
#if NET5_0_OR_GREATER 
            => GC.AllocateUninitializedArray<T>(count, pinned: false);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            => new T[count];
#endif
    }
}

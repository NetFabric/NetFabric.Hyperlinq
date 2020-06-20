using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValueType<T>()
            => default(T) is object;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UseDefault<T>(IEqualityComparer<T>? comparer)
            => IsValueType<T>() && (comparer is null || ReferenceEquals(comparer, EqualityComparer<T>.Default));
    }
}

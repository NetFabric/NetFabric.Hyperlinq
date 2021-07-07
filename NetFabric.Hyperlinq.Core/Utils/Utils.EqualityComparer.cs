using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValueType<T>()
            => default(T) is not null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UseDefaultComparer<T>(this IEqualityComparer<T>? comparer)
            => comparer is null || ReferenceEquals(comparer, EqualityComparer<T>.Default);
    }
}

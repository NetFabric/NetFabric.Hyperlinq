﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValueType<T>()
            => default(T) is {};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UseDefault<T>(IEqualityComparer<T>? comparer)
            => comparer is null || ReferenceEquals(comparer, EqualityComparer<T>.Default);
    }
}

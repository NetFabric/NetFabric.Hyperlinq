using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueObservable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TObservable AsValueObservable<TObservable, TDisposable, TSource>(this TObservable source)
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
            => source;
    }
}

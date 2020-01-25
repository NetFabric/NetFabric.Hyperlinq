using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TList, TSource>(this TList source, int index) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            var item = TryElementAt<TList, TSource>(source, index, 0, source.Count);
            return item.HasValue 
                ? item.Value 
                : Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource ElementAt<TList, TSource>(this TList source, int index, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var item = TryElementAt<TList, TSource>(source, index, skipCount, takeCount);
            return item.HasValue 
                ? item.Value 
                : Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var item = TryElementAt<TList, TSource>(source, index, 0, source.Count);
            return item.HasValue 
                ? item.Value 
                : default!;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var item = TryElementAt<TList, TSource>(source, index, skipCount, takeCount);
            return item.HasValue 
                ? item.Value 
                : default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TSource> TryElementAt<TList, TSource>(this TList source, int index)
            where TList : notnull, IReadOnlyList<TSource>
            => TryElementAt<TList, TSource>(source, index, 0, source.Count);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Maybe<TSource> TryElementAt<TList, TSource>(this TList source, int index, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || skipCount > source.Count || index >= takeCount 
                ? default 
                : new Maybe<TSource>(source[index + skipCount]);
    }
}

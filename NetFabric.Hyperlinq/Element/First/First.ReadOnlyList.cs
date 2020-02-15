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
        public static TSource First<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetFirst<TList, TSource>(source, 0, source.Count).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TList, TSource>(this TList source, Predicate<TSource> predicate) 
            where TList : notnull, IReadOnlyList<TSource>
            => predicate is null
                ? Throw.ArgumentNullException<TSource>(nameof(predicate))
                : GetFirst<TList, TSource>(source, predicate, 0, source.Count).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => GetFirst<TList, TSource>(source, 0, source.Count).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TList, TSource>(this TList source, Predicate<TSource> predicate) 
            where TList : notnull, IReadOnlyList<TSource>
            => predicate is null
                ? Throw.ArgumentNullException<TSource>(nameof(predicate))
                : GetFirst<TList, TSource>(source, predicate, 0, source.Count).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static (ElementResult Success, TSource Value) GetFirst<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count == 0 || skipCount > source.Count || takeCount < 1
                ? (ElementResult.Empty, default)
                : (ElementResult.Success, source[skipCount]);

        [Pure]
        static (ElementResult Success, TSource Value) GetFirst<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return (ElementResult.Success, source[index]);
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (int Index, TSource Value) GetFirst<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return (index, source[index]);
            }

            return ((int)ElementResult.Empty, default);
        }
    }
}

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
        [return: MaybeNull]
        public static TSource FirstOrDefault<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => GetFirst<TList, TSource>(source, 0, source.Count).DefaultOnEmpty();

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
        static (ElementResult Success, TSource Value, int Index) GetFirst<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        return (ElementResult.Success, item, index);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        return (ElementResult.Success, item, index);
                }
            }

            return (ElementResult.Empty, default, 0);
        }
    }
}

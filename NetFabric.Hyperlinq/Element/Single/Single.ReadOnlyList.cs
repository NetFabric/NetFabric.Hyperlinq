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
        public static TSource Single<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, 0, source.Count).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static TSource SingleOrDefault<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => GetSingle<TList, TSource>(source, 0, source.Count).DefaultOnEmpty();

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (source.Count == 0 || skipCount > source.Count || takeCount < 1)
                return (ElementResult.Empty, default);

            if (takeCount > 1 && skipCount < source.Count)
                return (ElementResult.NotSingle, default);

            return (ElementResult.Success, source[skipCount]);
        }

        [Pure]
        static (ElementResult Success, TSource Value) GetSingle<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                {
                    var value = source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index]))
                            return (ElementResult.NotSingle, default);
                    }

                    return (ElementResult.Success, value);
                }
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        static (ElementResult Success, TSource Value, int Index) GetSingle<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            for (var index = 0; index < takeCount; index++)
            {
                if (predicate(source[index + skipCount], index))
                {
                    var value = (ElementResult.Success, source[index + skipCount], index);

                    for (index++; index < takeCount; index++)
                    {
                        if (predicate(source[index + skipCount], index))
                            return (ElementResult.NotSingle, default, 0);
                    }

                    return value;
                }
            }

            return (ElementResult.Empty, default, 0);
        }
    }
}

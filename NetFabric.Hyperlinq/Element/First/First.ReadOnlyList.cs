using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => First<TList, TSource>(source, 0, source.Count);

        [Pure]
        static Option<TSource> First<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(source[skipCount]),
            };

        [Pure]
        static Option<TSource> First<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var item = source[index];
                if (predicate(item))
                    return Option.Some(item);
            }
            return Option.None;
        }

        [Pure]
        static Option<TSource> First<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[skipCount])),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[skipCount], 0)),
            };

        [Pure]
        static Option<TResult> First<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return Option.Some(selector(source[index]));
            }
            return Option.None;
        }
    }
}

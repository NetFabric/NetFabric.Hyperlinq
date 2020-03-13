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
            => First<TList, TSource>(source, 0, source.Count);

        [Pure]
        static TSource First<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TSource>(),
                _ => source[skipCount],
            };

        [Pure]
        static TSource First<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        static TSource First<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        return item;
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        return item;
                }
            }
            return Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult First<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TResult>(),
                _ => selector(source[skipCount]),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult First<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => Throw.EmptySequence<TResult>(),
                _ => selector(source[skipCount], 0),
            };

        [Pure]
        static  TResult First<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return selector(source[index]);
            }
            return Throw.EmptySequenceRef<TResult>();
        }

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TList, TSource>(this TList source) 
            where TList : notnull, IReadOnlyList<TSource>
            => FirstOrDefault<TList, TSource>(source, 0, source.Count);

        [Pure]
        [return: MaybeNull]
        public static TSource FirstOrDefault<TList, TSource>(this TList source, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                _ => source[skipCount],
            };

        [Pure]
        [return: MaybeNull]
        static TSource FirstOrDefault<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return default;
        }

        [Pure]
        [return: MaybeNull]
        static TSource FirstOrDefault<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        return item;
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        return item;
                }
            }
            return default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult FirstOrDefault<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                _ => selector(source[skipCount]),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult FirstOrDefault<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => takeCount switch
            {
                0 => default,
                _ => selector(source[skipCount], 0),
            };

        [Pure]
        static TResult FirstOrDefault<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return selector(source[index]);
            }
            return default;
        }    
    }
}

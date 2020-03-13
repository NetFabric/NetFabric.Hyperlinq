using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        /////////////////
        // ElementAt

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TList, TSource>(this TList source, int index) 
            where TList : notnull, IReadOnlyList<TSource>
            => ElementAt<TList, TSource>(source, index, 0, source.Count);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource ElementAt<TList, TSource>(this TList source, int index, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Throw.ArgumentOutOfRangeException<TSource>(nameof(index)) 
                : source[index + skipCount];

        [Pure]
        static TSource ElementAt<TList, TSource>(this TList source, int index, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return item;
                }
            }
            return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        static TSource ElementAt<TList, TSource>(this TList source, int index, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                if (skipCount == 0)
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return item;
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex + skipCount];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return item;
                    }
                }
            }
            return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult ElementAt<TList, TSource, TResult>(this TList source, int index, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Throw.ArgumentOutOfRangeException<TResult>(nameof(index)) 
                : selector(source[index + skipCount]);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ElementAt<TList, TSource, TResult>(this TList source, int index, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? Throw.ArgumentOutOfRangeException<TResult>(nameof(index)) 
                : selector(source[index + skipCount], index);

        [Pure]
        static TResult ElementAt<TList, TSource, TResult>(this TList source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return selector(item);
                }
            }
            return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
        }

        /////////////////
        // ElementAtOrDefault

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index) 
            where TList : notnull, IReadOnlyList<TSource>
            => ElementAtOrDefault<TList, TSource>(source, index, 0, source.Count);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? default 
                : source[index + skipCount];

        [Pure]
        static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index, Predicate<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return item;
                }
            }
            return default;
        }    

        [Pure]
        static TSource ElementAtOrDefault<TList, TSource>(this TList source, int index, PredicateAt<TSource> predicate, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                if (skipCount == 0)
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return item;
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex + skipCount];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return item;
                    }
                }
            }
            return default;
        }    

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult ElementAtOrDefault<TList, TSource, TResult>(this TList source, int index, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? default 
                : selector(source[index + skipCount]);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ElementAtOrDefault<TList, TSource, TResult>(this TList source, int index, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
            => index < 0 || index >= takeCount 
                ? default 
                : selector(source[index + skipCount], index);

        [Pure]
        static TResult ElementAtOrDefault<TList, TSource, TResult>(this TList source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount) 
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (index >= 0)
            {
                var end = skipCount + takeCount;
                for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                            return selector(item);
                }
            }
            return default;
        }
    }
}

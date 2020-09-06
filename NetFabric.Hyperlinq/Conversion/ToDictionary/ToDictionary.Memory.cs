using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null)
                Throw.ArgumentNullException(nameof(keySelector));

            return ToDictionary(source.Span, keySelector, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TPredicate>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
            => ToDictionary(source.Span, keySelector, comparer, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Dictionary<TKey, TSource> ToDictionaryAt<TSource, TKey, TPredicate>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
            => ToDictionaryAt(source.Span, keySelector, comparer, predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
        {
            if (keySelector is null)
                Throw.ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                Throw.ArgumentNullException(nameof(elementSelector));

            return ToDictionary(source.Span, keySelector, elementSelector, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TPredicate>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicate<TSource>
            => ToDictionary(source.Span, keySelector, elementSelector, comparer, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionaryAt<TSource, TKey, TElement, TPredicate>(this Memory<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TPredicate predicate)
            where TKey : notnull
            where TPredicate : struct, IPredicateAt<TSource>
            => ToDictionaryAt(source.Span, keySelector, elementSelector, comparer, predicate);
    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(enumerator.Current)
                : Option.None;
        }

        [Pure]
        static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    return Option.Some(item);
            }   

            return Option.None;
        }

        [Pure]
        static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate(item, index))
                        return Option.Some(item);
                }   
            }
            return Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(selector(enumerator.Current))
                : Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(selector(enumerator.Current, 0))
                : Option.None;
        }

        [Pure]
        static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    return Option.Some(selector(item));
            }   
            return Option.None;
        }
    }
}

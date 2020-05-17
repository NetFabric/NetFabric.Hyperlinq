using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate);

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).Select(selector);

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).Select(item => selector(item, 0));

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate).Select(selector);

        ////////////////////////////////
        // GetSingle 

        
        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;

                return enumerator.MoveNext() 
                    ? Option.None
                    : Option.Some(value);
            }
            return Option.None;
        }

        
        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    var value = enumerator.Current;

                    // found first, keep going until end or find second
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }
            return Option.None;
        }

        
        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                    {
                        var value = enumerator.Current;

                        // found first, keep going until end or find second
                        for (index++; enumerator.MoveNext(); index++)
                        {
                            if (predicate(enumerator.Current, index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            return Option.None;
        }
    }
}

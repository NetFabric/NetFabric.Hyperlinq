using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> Single<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> SingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => GetSingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).Select(selector);

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource>(source).Select(item => selector(item, 0));

        
        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate).Select(selector);

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

        
        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate.Invoke(enumerator.Current))
                {
                    var value = enumerator.Current;

                    // found first, keep going until end or find second
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }
            return Option.None;
        }

        
        static Option<TSource> GetSingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate.Invoke(enumerator.Current, index))
                    {
                        var value = enumerator.Current;

                        // found first, keep going until end or find second
                        for (index++; enumerator.MoveNext(); index++)
                        {
                            if (predicate.Invoke(enumerator.Current, index))
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

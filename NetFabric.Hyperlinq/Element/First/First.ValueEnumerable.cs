using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(enumerator.Current)
                : Option.None;
        }

        
        static Option<TSource> First<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    return Option.Some(item);
            }   

            return Option.None;
        }

        
        static Option<TSource> FirstAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    if (predicate.Invoke(item, index))
                        return Option.Some(item);
                }   
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(selector(enumerator.Current))
                : Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() 
                ? Option.Some(selector(enumerator.Current, 0))
                : Option.None;
        }

        
        static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    return Option.Some(selector(item));
            }   
            return Option.None;
        }
    }
}
